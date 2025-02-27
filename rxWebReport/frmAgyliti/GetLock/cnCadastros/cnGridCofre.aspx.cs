using DevExpress.Web;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace rxWebReport.frmRx.Agyliti.GetLock.cnCadastros
{
    public partial class cnGridCofre : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridCofre()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["cod_loja"]);

            var dsCombo = db.GetLockLojas.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "nome";
            comboColumn.PropertiesComboBox.ValueField = "cod_loja";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);

            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.GetLockCofres.ToList();
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newCofre = new GetLockCofre();
            newCofre.id_cofre = e.NewValues["id_cofre"]?.ToString(); // e.NewValues["id_cofre"] == null ? Guid.NewGuid().ToString() : e.NewValues["id_cofre"]?.ToString();
            newCofre.nome = e.NewValues["nome"]?.ToString();
            newCofre.nome = e.NewValues["nome"]?.ToString();
            newCofre.serie = e.NewValues["serie"]?.ToString();
            newCofre.tipo = e.NewValues["tipo"]?.ToString();
            newCofre.marca = e.NewValues["marca"]?.ToString();
            newCofre.modelo = e.NewValues["modelo"]?.ToString();
            newCofre.tamanho_malote = e.NewValues["tamanho_malote"]?.ToString();
            newCofre.cod_loja = e.NewValues["cod_loja"]?.ToString();

            db.GetLockCofres.Add(newCofre);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cofre = db.GetLockCofres.FirstOrDefault(l => l.id == gridKey);
            if (cofre != null)
            {
                cofre.id_cofre = e.NewValues["id_cofre"]?.ToString();
                cofre.nome = e.NewValues["nome"]?.ToString();
                cofre.nome = e.NewValues["nome"]?.ToString();
                cofre.serie = e.NewValues["serie"]?.ToString();
                cofre.tipo = e.NewValues["tipo"]?.ToString();
                cofre.marca = e.NewValues["marca"]?.ToString();
                cofre.modelo = e.NewValues["modelo"]?.ToString();
                cofre.tamanho_malote = e.NewValues["tamanho_malote"]?.ToString();
                cofre.cod_loja = e.NewValues["cod_loja"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cofre = db.GetLockCofres.FirstOrDefault(l => l.id == gridKey);

            db.GetLockCofres.Remove(cofre);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            bool foundIdCofre = false;
            string cofreId;

            if (e.IsNewRow)
            {
                cofreId = e.NewValues["id_cofre"].ToString();
                foundIdCofre = db.GetLockCofres.Any(c => c.id_cofre == cofreId);
            } else if (e.NewValues["id_cofre"].ToString() != e.OldValues["id_cofre"].ToString())
            {
                cofreId = e.NewValues["id_cofre"].ToString();
                foundIdCofre = db.GetLockCofres.Any(c => c.id_cofre == cofreId);
            }

            if (foundIdCofre)
            {
                AddError(e.Errors, ASPxGridView1.Columns["id_cofre"],
                     "Cofre precisa ter um ID Cofre único");
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