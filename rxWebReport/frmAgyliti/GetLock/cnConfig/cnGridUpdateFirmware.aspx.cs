using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using MQTTnet;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using rxWebReport.Models;
using rxWebReport.mqttClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace rxWebReport.frmAgyliti.GetLock.cnConfig
{
    public partial class cnGridUpdateFirmware : System.Web.UI.Page
    {
        private MqttClientHandler mqttClient;
        private ApplicationDbContext db;

        public cnGridUpdateFirmware()
        {
            this.mqttClient = new MqttClientHandler();
            mqttClient.PublisherStart();

            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxUploadControl1.FileSystemSettings.UploadFolder = ConfigurationManager.AppSettings["uploadFirmwarePath"];

            var files = Directory.GetFiles(ConfigurationManager.AppSettings["uploadFirmwarePath"]);

            for (int i = 0; i < files.Length; i++)
            {
                var item = Path.GetFileName(files[i]);
                ASPxFileName.Items.Add(item, item);
            }

            //ASPxComboCofreID.TextField = "nome";
            //ASPxComboCofreID.ValueField = "id_cofre";

            //ASPxComboCofreID.DataBind();

            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            //var ds = new EntityServerModeSource { QueryableSource = new ApplicationDbContext().GetLockMessageViews };

            LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "rxApp.Models.ApplicationDbContext", TableName = "GetLockMessageAckUpdateFirmwareViews" };
            lnsource.Selecting += EntityServerModeDataSource1_Selecting;

            ASPxGridView1.DataSource = lnsource;
        }
        string displayText = String.Empty;
        DateTime curDate;
        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.CreateCriteria)
                if (DateTime.TryParse(e.Value, CultureInfo.InvariantCulture, DateTimeStyles.None, out curDate))
                {
                    BinaryOperator op1 = new BinaryOperator("trackCreationTime", curDate, BinaryOperatorType.GreaterOrEqual);
                    BinaryOperator op2 = new BinaryOperator("trackCreationTime", curDate.AddMinutes(1), BinaryOperatorType.Less);
                    GroupOperator grOp = new GroupOperator(GroupOperatorType.And, op1, op2);
                    e.Criteria = grOp;
                    displayText = curDate.ToString("dd-MMMM-yyyy hh:mm");
                }

            if (e.Kind == DevExpress.Web.GridViewAutoFilterEventKind.ExtractDisplayText)
                e.Value = displayText;
        }

        protected void ASPxGridView1_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "trackCreationTime")
                return;
            ASPxDateEdit ed = e.Editor as ASPxDateEdit;
            ed.TimeSectionProperties.Visible = true;
            ed.TimeSectionProperties.TimeEditProperties.EditFormatString = "hh:mm";
        }

        protected void EntityServerModeDataSource1_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var db = new ApplicationDbContext();

            e.KeyExpression = "Id";

            e.QueryableSource = db.GetLockMessageAckUpdateFirmwareViews;
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (ASPxFileName.Value != null)
            {
                var version = "";
                var hash = "";
                var filenameParse = ASPxFileName.Value.ToString().Split('_');

                if (filenameParse.Count() > 1)
                {
                    var lastItem = filenameParse[filenameParse.Count() - 1];

                    if (ASPxFileName.Value.ToString().Substring(Math.Max(0, ASPxFileName.Value.ToString().Length - 5)) == ".srec")
                    {
                        version = lastItem.Substring(1, lastItem.Length - 6);
                        hash = SHA256CheckSum($"{ConfigurationManager.AppSettings["uploadFirmwarePath"]}/{ASPxFileName.Value.ToString()}");
                    }
                }

                List<string> selectedCofres = ASPxDropDownEdit1.Text.Split(',').ToList();

                if (selectedCofres.Count > 0 && selectedCofres[0] != "")
                {
                    var selectedCofreIds = selectedCofres.Select(x => x.Split('-')[1]);

                    foreach (var selectedCofreId in selectedCofreIds)
                    {
                        //var idCofre = "0";
                        //if (selectedCofreId != null)
                        //{
                        //    idCofre = ASPxComboCofreID.Value.ToString();
                        //}
                        var topic = $"/{selectedCofreId}/COMMAND";
                        //var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {idCofre}, ""CMD"": ""UPDATE-FIRMWARE"": {{ ""FILE"": ""safe_fw_v2.3.0.srec"", ""VERSION"": ""v2.3.0"", ""HASH"": ""1ed0c85d5f78fe9950cdffa9947df80ea2b7f4b638b4370e320f70e820984554"" }} }} }}";

                        var ackPayload = $@"{{ ""COMMAND"": {{ ""DESTINY"": {selectedCofreId}, ""CMD"": {{ ""UPDATE-FIRMWARE"": {{ ""FILE"": ""{ASPxFileName.Value}"", ""VERSION"": ""{version}"", ""HASH"": ""{hash}"" }} }} }} }}";
                        var message = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(ackPayload).WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce).WithRetainFlag(false).Build();

                        if (this.mqttClient.managedMqttClientPublisher != null)
                        {
                            Task.Run(async () => await mqttClient.managedMqttClientPublisher.PublishAsync(message));
                        }
                    }

                    ASPxDropDownEdit1.Text = "";

                    //ASPxComboCofreID.Value = "";
                }

                //mqttClient.PublisherStop();
            }
        }

        protected void ASPxDeleteDir_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["uploadFirmwarePath"]);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            ASPxFileName.Items.Clear();
        }

        //protected void ASPxComboCofreID_DataBinding(object sender, EventArgs e)
        //{
        //    var cofreList = db.GetLockCofres.OrderBy(c => c.nome).ToList();

        //    ASPxComboCofreID.DataSource = cofreList;
        //}

        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            //string filePath = String.Format($"{ConfigurationManager.AppSettings["uploadFirmwarePath"]}/{{0}}", e.UploadedFile.FileName);
            //e.UploadedFile.SaveAs(Server.MapPath(filePath));

            var fileName = e.UploadedFile.FileName;

            if (File.Exists($"{ConfigurationManager.AppSettings["uploadFirmwarePath"]}/{fileName}"))
            {
                fileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            }
            
            e.UploadedFile.SaveAs($"{ConfigurationManager.AppSettings["uploadFirmwarePath"]}/{fileName}");
        }

        protected void ASPxListBoxCofre_Init(object sender, EventArgs e)
        {
            ASPxListBox lb = sender as ASPxListBox;

            var cofreList = db.GetLockCofres.OrderBy(c => c.nome).ToList();

            foreach (var cofre in cofreList)
            {
                lb.Items.Add($"{cofre.nome.Trim()}-{cofre.id_cofre}", cofre.id_cofre);
            }
        }

        public string SHA256CheckSum(string filePath)
        {
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return BitConverter.ToString(SHA256.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
            }
        }

 
    }
}
