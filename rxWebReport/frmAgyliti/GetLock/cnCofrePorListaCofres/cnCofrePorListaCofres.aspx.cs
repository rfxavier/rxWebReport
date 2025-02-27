using DevExpress.DashboardWeb;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.dashClasses;
using rxWebReport.dataObjClasses;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rxWebReport.frmAgyliti.GetLock.cnCofrePorListaCofres
{
    public partial class cnCofrePorListaCofres : System.Web.UI.Page
    {
        private ApplicationUserManager userManager;

        public cnCofrePorListaCofres()
        {
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxDashboard1.DashboardType = typeof(dashCnCofrePorCliente);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e)
        {
            if (User.IsInRole("UserCofre"))
            {
                var db = new ApplicationDbContext();

                var userId = Page.User.Identity.GetUserId();
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

                var cofreList = user.GetLockCofres.Select(c => c.id_cofre).ToList();

                e.Data = dsCofre.GetDepositosMessageViewsPorListaCofres((List<string>) cofreList);
            }
        }

        protected void ASPxDashboard1_ConfigureDataReloadingTimeout(object sender, ConfigureDataReloadingTimeoutWebEventArgs e)
        {
            e.DataReloadingTimeout = TimeSpan.FromMinutes(0);
        }
    }
}
