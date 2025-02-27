using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rxWebReport
{
    public partial class LoginAux : System.Web.UI.Page
    {
        protected string SuccessMessage { get; private set; }

        private bool HasPassword(ApplicationUserManager manager)
        {
            var appUser = manager.FindById(User.Identity.GetUserId());

            return (appUser != null); // AndAlso appUser.PasswordHash IsNot Nothing)
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = Request.QueryString["ReturnUrl"];
            var loginpopup =Request.QueryString["loginpopup"];

            if (loginpopup == "S")
            {
                Control ctrl1 = AppUtils.FindControlRecursive(Master, "ErrorMessage");
                if (ctrl1 != null)
                    ((Literal) ctrl1).Text = "Conteúdo protegido. Faça login para continuar";
            }

            if (!IsPostBack)
            {
                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    // Form.Action = ResolveUrl("~/Default")
                    Form.Action = ResolveUrl("~/LoginAux.aspx");

                    SuccessMessage = message == "ChangePwdSuccess" ? "Sua senha foi alterada com sucesso." : message == "SetPwdSuccess" ? "Sua senha foi criada." : message == "RemoveLoginSuccess" ? "The account was removed." : message == "AddPhoneNumberSuccess" ? "Phone number has been added" : message == "RemovePhoneNumberSuccess" ? "Phone number was removed" : string.Empty;
                    SuccessMessagePlaceHolder.Visible = !string.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void btnLoginNow_Click(object sender, EventArgs e)
        {
            // BLOCO DE CÓDIGO PARA TRATAR AUTENTICAÇÃO ASP.net IDENTITY BI4T AUTENTICAÇÃO authMode4T = RepoLocal

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // This doen't count login failures towards account lockout
            // To enable password failures to trigger lockout, change to shouldLockout := True
            Session["DummySession"] = "DummySession";

            var result = signinManager.PasswordSignIn(txtUsuario.Text, txtPassword.Text, true, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                {
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    break;
                }

                default:
                {
                    ErrorMessage.Text = "Login inválido";
                    // ErrorMessage.Visible = True
                    break;
                }
            }
        }
    }
}