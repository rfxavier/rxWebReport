using DevExpress.Web;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace rxWebReport.frmAgyliti.GetLock.cnCadastros
{
    public partial class cnGridCliente : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridCliente()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["cod_rede"]);

            var dsCombo = db.GetLockRedes.ToList();

            comboColumn.PropertiesComboBox.DataSource = dsCombo;
            comboColumn.PropertiesComboBox.TextField = "nome";
            comboColumn.PropertiesComboBox.ValueField = "cod_rede";
            comboColumn.PropertiesComboBox.ValueType = typeof(string);
            
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.GetLockClientes.ToList();
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var newCliente = new GetLockCliente();
            newCliente.cod_cliente = e.NewValues["cod_cliente"] == null ? Guid.NewGuid().ToString() : e.NewValues["cod_cliente"]?.ToString();
            newCliente.nome = e.NewValues["nome"]?.ToString();
            newCliente.cod_rede = e.NewValues["cod_rede"]?.ToString();
            newCliente.razao_social = e.NewValues["razao_social"]?.ToString();
            newCliente.cnpj = e.NewValues["cnpj"]?.ToString();
            newCliente.endereco = e.NewValues["endereco"]?.ToString();
            newCliente.complemento = e.NewValues["complemento"]?.ToString();
            newCliente.bairro = e.NewValues["bairro"]?.ToString();
            newCliente.cidade = e.NewValues["cidade"]?.ToString();
            newCliente.uf = e.NewValues["uf"]?.ToString();
            newCliente.CEP = e.NewValues["CEP"]?.ToString();
            newCliente.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
            newCliente.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
            newCliente.pessoa_contato = e.NewValues["pessoa_contato"]?.ToString();
            newCliente.email = e.NewValues["email"]?.ToString();
            newCliente.telefone = e.NewValues["telefone"]?.ToString();

            db.GetLockClientes.Add(newCliente);
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
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cliente = db.GetLockClientes.FirstOrDefault(l => l.id == gridKey);
            if (cliente != null)
            {
                cliente.cod_cliente = e.NewValues["cod_cliente"]?.ToString();
                cliente.nome = e.NewValues["nome"]?.ToString();
                cliente.cod_rede = e.NewValues["cod_rede"]?.ToString();
                cliente.razao_social = e.NewValues["razao_social"]?.ToString();
                cliente.cnpj = e.NewValues["cnpj"]?.ToString();
                cliente.endereco = e.NewValues["endereco"]?.ToString();
                cliente.complemento = e.NewValues["complemento"]?.ToString();
                cliente.bairro = e.NewValues["bairro"]?.ToString();
                cliente.cidade = e.NewValues["cidade"]?.ToString();
                cliente.uf = e.NewValues["uf"]?.ToString();
                cliente.CEP = e.NewValues["CEP"]?.ToString();
                cliente.latitude = e.NewValues["latitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["latitude"]);
                cliente.longitude = e.NewValues["longitude"] == null ? 0 : Convert.ToDecimal(e.NewValues["longitude"]);
                cliente.pessoa_contato = e.NewValues["pessoa_contato"]?.ToString();
                cliente.email = e.NewValues["email"]?.ToString();
                cliente.telefone = e.NewValues["telefone"]?.ToString();

                db.SaveChanges();
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var gridKey = (long)Convert.ToInt64(e.Keys["id"]);
            var cliente = db.GetLockClientes.FirstOrDefault(l => l.id == gridKey);

            db.GetLockClientes.Remove(cliente);
            db.SaveChanges();

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["cod_rede"] == null)
            {
                AddError(e.Errors, ASPxGridView1.Columns["cod_rede"],
                     "Rede é obrigatório");
            }

            bool foundIdCliente = false;
            string clienteId;

            if (e.IsNewRow)
            {
                clienteId = e.NewValues["cod_cliente"].ToString();
                foundIdCliente = db.GetLockClientes.Any(c => c.cod_cliente == clienteId);
            }
            else if (e.NewValues["cod_cliente"].ToString() != e.OldValues["cod_cliente"].ToString())
            {
                clienteId = e.NewValues["cod_cliente"].ToString();
                foundIdCliente = db.GetLockClientes.Any(c => c.cod_cliente == clienteId);
            }

            if (foundIdCliente)
            {
                AddError(e.Errors, ASPxGridView1.Columns["cod_cliente"],
                     "Cliente precisa ter um Código Cliente único");
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