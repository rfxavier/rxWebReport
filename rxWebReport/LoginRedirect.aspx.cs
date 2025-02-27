using System;
using System.Web;
using System.Web.UI;

namespace rxWebReport
{
    public partial class LoginRedirect : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logout = Page.Request.QueryString["logout"];

            if (logout == "S")
            {
                Page.Session["DummySession"] = "DummySession";

                Context.GetOwinContext().Authentication.SignOut();
                Page.Response.Redirect("~/Default.aspx");
            }

            var returnUrl = Page.Request.QueryString["ReturnUrl"];
            string redirectUrl = string.Empty;

            if (!String.IsNullOrEmpty(returnUrl))
                redirectUrl = "~/LoginAux.aspx?loginpopup=S&ReturnUrl=" + returnUrl;
            else
                redirectUrl = "~/LoginAux.aspx";

            Page.Response.Redirect(redirectUrl);

        }
    }
}