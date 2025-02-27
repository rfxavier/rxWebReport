using DevExpress.Web;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.UI.WebControls;

namespace rxWebReport.frmAgyliti.GetLock.cnConfig
{
    public partial class cnGridGetStatusBitProfile : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridGetStatusBitProfile()
        {
            db = new ApplicationDbContext();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["StatusType"]);

            var statusTypeList = new[] { new { StatusType = "DeviceSensors" }, new { StatusType = "BillMachineStatus" }, new { StatusType = "BillMachineError" } }.ToList();

            comboColumn.PropertiesComboBox.DataSource = statusTypeList;
            comboColumn.PropertiesComboBox.TextField = "StatusType";
            comboColumn.PropertiesComboBox.ValueField = "StatusType";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            var ds = db.GetLockGetStatusBitProfiles.AsNoTracking().ToList();
            var dsDeviceSensors = ds.Where(d => d.StatusType == "DeviceSensors").OrderBy(f => f.Bit).ToList();
            var dsBillMachineStatus = ds.Where(d => d.StatusType == "BillMachineStatus").OrderBy(f => f.Bit).ToList();
            var dsBillMachineError = ds.Where(d => d.StatusType == "BillMachineError").OrderBy(f => f.Bit).ToList();

            dsDeviceSensors.AddRange(dsBillMachineStatus);
            dsDeviceSensors.AddRange(dsBillMachineError);

            ASPxGridView1.DataSource = dsDeviceSensors;
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {   

            var newGetStatusBitProfile = new GetLockGetStatusBitProfile();
            newGetStatusBitProfile.StatusType = e.NewValues["StatusType"]?.ToString();
            newGetStatusBitProfile.Bit = e.NewValues["Bit"] == null ? 0 : Convert.ToInt32(e.NewValues["Bit"]);
            newGetStatusBitProfile.Caption = e.NewValues["Caption"]?.ToString();

            db.GetLockGetStatusBitProfiles.Add(newGetStatusBitProfile);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException f)
            {

                throw;
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["Id"]);
            var getStatusBitProfile = db.GetLockGetStatusBitProfiles.FirstOrDefault(l => l.Id == gridKey);
            if (getStatusBitProfile != null)
            {
                getStatusBitProfile.StatusType = e.NewValues["StatusType"]?.ToString();
                getStatusBitProfile.Bit = e.NewValues["Bit"] == null ? 0 : Convert.ToInt32(e.NewValues["Bit"]);
                getStatusBitProfile.Caption = e.NewValues["Caption"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["Id"]);
            var getStatusBitProfile = db.GetLockGetStatusBitProfiles.FirstOrDefault(l => l.Id == gridKey);

            db.GetLockGetStatusBitProfiles.Remove(getStatusBitProfile);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //if (e.NewValues["cod_cliente"] == null)
            //{
            //    AddError(e.Errors, ASPxGridView1.Columns["cod_cliente"],
            //         "Cliente é obrigatório");
            //}

            //bool foundIdLoja = false;
            //string lojaId;

            //if (e.IsNewRow)
            //{
            //    lojaId = e.NewValues["cod_loja"].ToString();
            //    foundIdLoja = db.GetLockLojas.Any(c => c.cod_loja == lojaId);
            //}
            //else if (e.NewValues["cod_loja"].ToString() != e.OldValues["cod_loja"].ToString())
            //{
            //    lojaId = e.NewValues["cod_loja"].ToString();
            //    foundIdLoja = db.GetLockLojas.Any(c => c.cod_loja == lojaId);
            //}

            //if (foundIdLoja)
            //{
            //    AddError(e.Errors, ASPxGridView1.Columns["cod_loja"],
            //         "Loja precisa ter um Código Loja único");
            //}
            //if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
            //    e.RowError = "Corrija todos os erros";
        }
        void AddError(Dictionary<GridViewColumn, string> errors,
             GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

    }
}