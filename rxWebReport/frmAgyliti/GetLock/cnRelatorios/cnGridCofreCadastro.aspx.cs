using rxWebReport.Models;
using System;
using System.Linq;

namespace rxWebReport.frmAgyliti.GetLock.cnRelatorios
{
    public partial class cnGridCofreCadastro : System.Web.UI.Page
    {
        private ApplicationDbContext db;

        public cnGridCofreCadastro()
        {
            db = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            ASPxGridView1.DataSource = db.GetLockCofreCadastroViews.ToList();
        }
    }
}