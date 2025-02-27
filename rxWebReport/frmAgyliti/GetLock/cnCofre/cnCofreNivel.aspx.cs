using DevExpress.DashboardWeb;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.dashClasses;
using rxWebReport.dataObjClasses;
using rxWebReport.Models;
using System;
using System.Linq;
using System.Web;

namespace rxWebReport.frmAgyliti.GetLock.cnCofre
{
    public partial class cnCofreNivel : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnCofreNivel()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofreNivel);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            if (User.IsInRole("UserClient"))
            {
                var db = new ApplicationDbContext();

                var user = userManager.FindById(User.Identity.GetUserId());
                var cliente = db.GetLockClientes.FirstOrDefault(l => l.id == user.GetLockLojaId);

                if (user.GetLockClienteId != null) e.Data = dsCofre.GetCofreNivelPorCliente((long)user.GetLockClienteId);
            } else
            {
                e.Data = dsCofre.GetCofreNivel();
            }
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(0);
        }

    }
}