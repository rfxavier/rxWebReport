using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace rxWebReport.frmRx.Agyliti.GetLock.cnGridSemLoja
{
    public partial class cnGridSemLoja : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;

        public cnGridSemLoja()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            db = new ApplicationDbContext();
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's contentCallEvent event
            Master.contentCallEvent += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            comboLoja.TextField = "nome";
            comboLoja.ValueField = "cod_loja";
            comboLoja.ValueType = typeof(string);

            comboLoja.DataBind();

            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            //var ds = new EntityServerModeSource { QueryableSource = new ApplicationDbContext().GetLockMessageViews };

            LinqServerModeDataSource lnsource = new LinqServerModeDataSource { ContextTypeName = "rxApp.Models.ApplicationDbContext", TableName = "GetLockMessageViews" };
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

            e.KeyExpression = "id";

            if (Session["dateStart"] != null && (Session["dateEnd"] != null))
            {
                var dateStart = (DateTime)Session["dateStart"];
                var dateEnd = (DateTime)Session["dateEnd"];

                var ds = db.GetLockMessageViews.Where(g => g.cod_loja == null && g.data_tmst_end_datetime >= dateStart && g.data_tmst_end_datetime <= dateEnd).ToList();

                e.QueryableSource = db.GetLockMessageViews.Where(g => g.cod_loja == null && g.data_tmst_end_datetime >= dateStart && g.data_tmst_end_datetime <= dateEnd);
            }
            else if (Session["dateStart"] != null && (Session["dateEnd"] == null))
            {
                var dateStart = (DateTime)Session["dateStart"];
                e.QueryableSource = db.GetLockMessageViews.Where(g => g.cod_loja == null && g.data_tmst_end_datetime >= dateStart);
            }
            else if (Session["dateStart"] == null && (Session["dateEnd"] != null))
            {
                var dateEnd = (DateTime)Session["dateEnd"];
                e.QueryableSource = db.GetLockMessageViews.Where(g => g.cod_loja == null && g.data_tmst_end_datetime <= dateEnd);
            }
            else
            {
                e.QueryableSource = db.GetLockMessageViews.Where(g => false);
            }

        }
        protected void UpdatePanel(object sender, EventArgs e)
        {
            updateDetails.Update(); //refresh the update pabel
        }

        protected void UpdatePanel_Unload(object sender, EventArgs e)
        {
            RegisterUpdatePanel((UpdatePanel)sender);
        }
        protected void RegisterUpdatePanel(UpdatePanel panel)
        {
            var sType = typeof(ScriptManager);
            var mInfo = sType.GetMethod("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel", BindingFlags.NonPublic | BindingFlags.Instance);
            if (mInfo != null)
                mInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] { panel });
        }

        protected void ASPxGridView1_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            var selectedItemsCount = ASPxGridView1.GetSelectedFieldValues("id").Count();
            lbTitle.Text = $"{selectedItemsCount.ToString()}";
            ASPxHiddenField1["selIds"] = string.Join(",", ASPxGridView1.GetSelectedFieldValues("id").Select(x => x));
            ASPxPopupControl1.ShowOnPageLoad = true;
        }

        protected void btOK_Click(object sender, EventArgs e)
        {
            var b = ASPxHiddenField1["selIds"];
            using (var ctx = new ApplicationDbContext())
            {
                int noOfRowUpdated = ctx.Database.ExecuteSqlCommand($"UPDATE message SET cod_loja = {comboLoja.Value} where id IN (${b.ToString()})");
            }
            ASPxGridView1.Selection.UnselectAll();
            ASPxPopupControl1.ShowOnPageLoad = false;
            //updateDetails.Update(); //refresh the update panel
            ASPxGridView1.DataBind();

        }

        protected void comboLoja_DataBinding(object sender, EventArgs e)
        {
            var dsCombo = db.GetLockLojaClienteRedeViews.ToList();

            comboLoja.DataSource = dsCombo;
        }
    }
}