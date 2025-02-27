using DevExpress.Web;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rxWebReport
{
    public partial class Default : System.Web.UI.Page
    {
        protected string SuccessMessage { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = Request.QueryString["ReturnUrl"];
            var loginpopup = Request.QueryString["loginpopup"];

            if (loginpopup == "S")
            {
                Control ctrl1 = AppUtils.FindControlRecursive(Master, "ErrorMessage");
                if (ctrl1 != null)
                    ((Literal) ctrl1).Text = "Conteúdo protegido. Faça login para continuar";


                Control ctrl2 = AppUtils.FindControlRecursive(Master, "LogonControl");
                if (ctrl2 != null)
                    ((ASPxPopupControl) ctrl2).ShowOnPageLoad = true;
            }

            if (!IsPostBack)
            {
                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Default");

                    SuccessMessage = message == "ChangePwdSuccess" ? "Sua senha foi alterada com sucesso." :
                        message == "SetPwdSuccess" ? "Sua senha foi criada." :
                        message == "RemoveLoginSuccess" ? "The account was removed." :
                        message == "AddPhoneNumberSuccess" ? "Phone number has been added" :
                        message == "RemovePhoneNumberSuccess" ? "Phone number was removed" : string.Empty;
                    SuccessMessagePlaceHolder.Visible = !string.IsNullOrEmpty(SuccessMessage);
                }
            }

            //if (Page.User.IsInRole("AdmPortal"))
            //{
            //    Response.Redirect("~/frmAgyliti/GetLock/cnCofre/cnCofre.aspx");
            //}
            //else if (Page.User.IsInRole("UserClient"))
            //{
            //    Response.Redirect("~/frmAgyliti/GetLock/cnCofrePorCliente/cnCofrePorCliente.aspx");
            //}
        }
    }
}