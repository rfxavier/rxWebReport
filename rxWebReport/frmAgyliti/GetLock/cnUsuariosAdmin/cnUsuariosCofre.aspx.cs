using DevExpress.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace rxWebReport.frmAgyliti.GetLock.cnUsuariosAdmin
{
    public partial class cnUsuariosCofre : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext db;

        public cnUsuariosCofre()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ApplicationDbContext();

            GridUsers.DataBind();
        }

        protected void GridUsers_DataBinding(object sender, EventArgs e)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //Get user role
            var clientRole = roleManager.FindByName("UserCofre");

            GridUsers.DataSource = userManager.Users.Where(x => x.Roles.Any(role => role.RoleId == clientRole.Id)).ToList();
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            UpdatePasswordField(npsw.Text);
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void UpdatePasswordField(string newPassword)
        {
            int index = GridUsers.EditingRowVisibleIndex;
            DataTable dt = Session["data"] as DataTable;
            dt.Rows[0]["NewPwd"] = newPassword;
            Session["data"] = dt;

        }

        protected void GridUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = new ApplicationUser() { UserName = e.NewValues["UserName"].ToString(), Email = e.NewValues["UserName"].ToString() };

            IdentityResult result = manager.Create(user, e.NewValues["PasswordHash"].ToString());
            if (result.Succeeded)
            {

                manager.AddToRole(user.Id, "UserCofre");

                e.Cancel = true;
                gridView.CancelEdit();
            }
            else
            {
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void GridUsers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            DataTable dt = new DataTable();

            dt = Session["data"] as DataTable;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = manager.FindById(e.Keys[0].ToString());

            manager.Update(user);

            if (dt.Rows[0]["NewPwd"].ToString() != "")
            {
                string token = manager.GeneratePasswordResetToken(user.Id);
                IdentityResult result = userManager.ResetPassword(user.Id, token, dt.Rows[0]["NewPwd"].ToString());

                if (result.Succeeded)
                {
                    e.Cancel = true;
                    gridView.CancelEdit();
                }
                else
                {
                    //AddErrors(result);
                }
            }
            else
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
        }

        protected void GridUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            ASPxGridView gridView = (ASPxGridView)sender;

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            IdentityResult result = manager.Delete(manager.FindById(e.Keys[0].ToString()));
            if (result.Succeeded)
            {
                e.Cancel = true;
                gridView.CancelEdit();
            }
            else
            {
                //AddErrors(result);
            }
        }

        protected void GridUsers_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            DataTable dt = new DataTable();

            if (Session["data"] == null)
            {
                dt.Columns.Add("NewPwd", typeof(string));

                dt.Rows.Add(new object[] { "" });
                Session["data"] = dt;
            }
            else
            {
                dt = Session["data"] as DataTable;
                dt.Rows[0]["NewPwd"] = "";
            }
        }

        protected void GridUsers_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["UserName"] == null)
            {
                AddError(e.Errors, GridUsers.Columns["UserName"],
                    "Usuário precisa ser preenchido");
            }

            bool foundUserName = false;
            string userName;

            if (e.IsNewRow)
            {
                userName = e.NewValues["UserName"].ToString();
                foundUserName = db.Users.Any(u => u.UserName == userName);
            }
            else if (e.NewValues["UserName"].ToString() != e.OldValues["UserName"].ToString())
            {
                AddError(e.Errors, GridUsers.Columns["UserName"],
                     "Não é possível editar nome do usuário");
            }

            if (foundUserName)
            {
                AddError(e.Errors, GridUsers.Columns["UserName"],
                     "Usuário precisa ter um nome único");
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