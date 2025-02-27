using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rxWebReport.frmAgyliti.GetLock.cnUsuariosAdmin
{
    public partial class cnUsuariosCofreDetalhe : System.Web.UI.Page
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;

        public cnUsuariosCofreDetalhe()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //db.Database.Log = message => System.Diagnostics.Debug.WriteLine(message);
        }

        private class CofresCombo
        {
            public long CofreId { get; set; }
            public string Nome { get; set; }
            public string DisplayText { get; set; }
            public string Id_cofre { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && string.IsNullOrEmpty(Request.QueryString["id"]))
            {

            }
            else
            {
                Session["currentUserId"] = Request.QueryString["id"];

                var userId = Session["currentUserId"].ToString();
                var user = userManager.Users.FirstOrDefault(ul => ul.Id == userId);
                ASPxLabel1.Text = user.UserName + ": detalhamento de cofres";

                var comboColumn = ((GridViewDataComboBoxColumn)ASPxGridView1.Columns["CofreId"]);

                var dsCombo = db.GetLockCofres.Select(c => new CofresCombo { CofreId = c.id, Nome = c.nome, DisplayText = c.id_cofre + " - " + c.nome, Id_cofre = c.id_cofre }).OrderBy(cc => cc.Id_cofre).ToList();
                //For debugging purposes
                //var deb = db.Users.Include(u => u.GetLockCofres).FirstOrDefault(ul => ul.Id == userId);

                comboColumn.PropertiesComboBox.DataSource = dsCombo;
                comboColumn.PropertiesComboBox.TextField = "DisplayText";
                comboColumn.PropertiesComboBox.ValueField = "Id_cofre";
                comboColumn.PropertiesComboBox.ValueType = typeof(string);

              ASPxGridView1.DataBind();
            }
        }

        private class CofreIds
        {
            public string UserId { get; set; }
            public string CofreId { get; set; }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            var userId = Session["currentUserId"].ToString();
            //var user = userManager.Users.Include(u => u.GetLockCofres).FirstOrDefault(ul => ul.Id == userId);
            
            ApplicationUser user = null;

            using (var ctx = new ApplicationDbContext())
            {
                user = ctx.Database.SqlQuery<ApplicationUser>(
                    @"SELECT u.* FROM AspNetUsers u WHERE u.Id = @p0", userId).FirstOrDefault();

                if (user != null)
                {
                    user.GetLockCofres = ctx.Database.SqlQuery<GetLockCofre>(
                        @"SELECT ISNULL(c.id, 0) AS id, ISNULL(c.id_cofre, uc.id_cofre) AS id_cofre, ISNULL(c.nome, uc.id_cofre) AS nome, c.serie, c.tipo, c.marca, c.modelo, c.tamanho_malote, c.trackLastWriteTime, c.trackCreationTime, c.cod_loja FROM AspNetUserCofres uc LEFT OUTER JOIN cofre c ON uc.id_cofre = c.id_cofre WHERE uc.UserId = @p0", userId).ToList();
                }
            }

            var ds = user.GetLockCofres.Select(c => new CofreIds { UserId = userId, CofreId = c.id_cofre }).ToList();

            ASPxGridView1.DataSource = ds;
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string cofreId = (string)e.NewValues["CofreId"];

            //var cofre = db.GetLockCofres.FirstOrDefault(c => c.id == cofreId );

            //var user = userManager.FindById(Session["currentUserId"].ToString());

            using (var ctx = new ApplicationDbContext())
            {
                int noOfRowUpdated = ctx.Database.ExecuteSqlCommand($"INSERT INTO AspNetUserCofres ( UserId, id_cofre ) VALUES ('{Session["currentUserId"].ToString()}', '{cofreId}')");
            }

            e.Cancel = true;
            ASPxGridView1.CancelEdit();

            //user.GetLockCofres.Add(cofre);
            //var result = userManager.Update(user);

            //if (result.Succeeded)
            //{
            //    e.Cancel = true;
            //    ASPxGridView1.CancelEdit();
            //}
            //else
            //{
            //    //AddErrors(result);
            //}
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            using (var ctx = new ApplicationDbContext())
            {
                string cofreId = (string)e.Keys["CofreId"];
                string userId = Session["currentUserId"].ToString();

                // Delete the specific record from the AspNetUserCofres table
                int rowsAffected = ctx.Database.ExecuteSqlCommand(
                    @"DELETE FROM AspNetUserCofres WHERE UserId = @p0 AND id_cofre = @p1",
                    userId,
                    cofreId
                );

                // Optional: You can log or handle the result if necessary
                if (rowsAffected > 0)
                {
                    // Record deleted successfully
                    e.Cancel = true;
                    ASPxGridView1.CancelEdit();
                }
                else
                {
                    // No matching record found
                }
            }

            //var user = userManager.FindById(Session["currentUserId"].ToString());
            //var cofre = user.GetLockCofres.FirstOrDefault(c => c.id_cofre == cofreId);

            //user.GetLockCofres.Remove(cofre);
            //var result = userManager.Update(user);

            //if (result.Succeeded)
            //{
            //    e.Cancel = true;
            //    ASPxGridView1.CancelEdit();
            //}
            //else
            //{
            //    //AddErrors(result);
            //}
        }

        protected void ASPxGridView1_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
        }

        void AddError(Dictionary<GridViewColumn, string> errors,
             GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

    }
}