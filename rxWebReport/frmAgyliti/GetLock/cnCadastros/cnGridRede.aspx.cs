using DevExpress.Web;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rxWebReport.frmAgyliti.GetLock.cnCadastros
{
    public partial class cnGridRede : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridRede()
        {
            db = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            var newRede = new GetLockRede();

            newRede.cod_rede = e.NewValues["cod_rede"] == null ? Guid.NewGuid().ToString() : e.NewValues["cod_rede"]?.ToString();
            newRede.nome = e.NewValues["nome"]?.ToString();

            db.GetLockRedes.Add(newRede);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            bool foundIdRede = false;
            string redeId;

            if (e.IsNewRow)
            {
                redeId = e.NewValues["cod_rede"].ToString();
                foundIdRede = db.GetLockRedes.Any(c => c.cod_rede == redeId);
            }
            else if (e.NewValues["cod_rede"].ToString() != e.OldValues["cod_rede"].ToString())
            {
                redeId = e.NewValues["cod_rede"].ToString();
                foundIdRede = db.GetLockRedes.Any(c => c.cod_rede == redeId);
            }

            if (foundIdRede)
            {
                AddError(e.Errors, ASPxGridView1.Columns["cod_rede"],
                     "Rede precisa ter um Código Rede único");
            }
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0)
                e.RowError = "Corrija todos os erros";
        }
        void AddError(Dictionary<GridViewColumn, string> errors,
             GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
    }
}