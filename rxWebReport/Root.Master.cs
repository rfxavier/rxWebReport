using System;
using System.Web.UI;

namespace rxWebReport
{
    public partial class Root : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxMenu1.Visible = Page.User?.Identity.IsAuthenticated == true;
        }

        protected void ASPxMenu1_ItemDataBound(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Depth == 0)
            {
                e.Item.ItemStyle.ForeColor = System.Drawing.Color.White;
            } else if (e.Item.Depth == 1)
            {
                e.Item.ItemStyle.ForeColor = System.Drawing.Color.Black;
                e.Item.ItemStyle.HoverStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#DEDFDA");
            }
      }
    }
}