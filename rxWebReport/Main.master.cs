using DevExpress.Web.ASPxTreeList;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace rxWebReport
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private ApplicationDbContext db;
        private ApplicationUserManager userManager;
        object ds;

        public Main()
        {
            db = new ApplicationDbContext();
            userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.IsInRole("AdmMaster") || Page.User.IsInRole("AdmPortal") || Page.User.IsInRole("UserClient") || Page.User.IsInRole("UserCofre"))
            {
                ASPxTreeList1.DataBind();
                ASPxTreeList1.ExpandAll();
                ASPxTreeList1.SettingsSelection.Recursive = true;

            }
            else if(Page.User.IsInRole("User"))
            {
                ASPxTreeList1.Visible = false;
            }
            else
            {
                ASPxTreeList1.Visible = false;
                deStart.Visible = false;
                teStart.Visible = false;
                deEnd.Visible = false;
                teEnd.Visible = false;
                ASPxButton1.Visible = false;
                dateTextStart.Visible = false;
                dateTextEnd.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                deStart.Value = Session["dateStart"] ?? new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
                teStart.Value = Session["dateStart"] ?? new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);

                deEnd.Value = Session["dateEnd"] ?? new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 23, 59, 59);
                teEnd.Value = Session["dateEnd"] ?? new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 23, 59, 59);
            }
        }

        protected void ASPxTreeList1_DataBinding(object sender, EventArgs e)
        {
            ds = db.GetLockLojaClienteRedeViews.AsNoTracking().ToList();

            var dsLojaClienteRedeView = ds as List<GetLockLojaClienteRedeView>;

            List<TreeListDataSource> dsTodosGroup;
            List<TreeListDataSource> dsRedeGroup;
            List<TreeListDataSource> dsClienteGroup;
            List<TreeListDataSource> dsLojaGroup;

            if (Page.User.IsInRole("UserClient"))
            {
                var user = userManager.FindById(Page.User.Identity.GetUserId());

                dsTodosGroup = new List<TreeListDataSource> { new TreeListDataSource { id = "T0", nome = "Todos", parentId = "" } };

                dsRedeGroup = dsLojaClienteRedeView.Where(p => p.id_cliente == user.GetLockClienteId).GroupBy(x => new { idRede = "R" + x.id_rede.ToString(), nomeRede = x.nome_rede }).Select(y => new TreeListDataSource() { id = y.Key.idRede, parentId = "", nome = y.Key.nomeRede }).ToList();

                dsClienteGroup = dsLojaClienteRedeView.Where(p => p.id_cliente == user.GetLockClienteId).GroupBy(x => new { idCliente = "C" + x.id_cliente.ToString(), nomeCliente = x.nome_cliente, idRede = x.id_rede }).Select(y => new TreeListDataSource() { id = y.Key.idCliente, parentId = "R" + y.Key.idRede.ToString(), nome = y.Key.nomeCliente }).ToList();

                dsLojaGroup = dsLojaClienteRedeView.Where(p => p.id_cliente == user.GetLockClienteId).GroupBy(x => new { idLoja = "L" + x.id_loja.ToString(), nomeLoja = x.nome_loja, idCliente = x.id_cliente }).Select(y => new TreeListDataSource() { id = y.Key.idLoja, parentId = "C" + y.Key.idCliente.ToString(), nome = y.Key.nomeLoja }).ToList();
            }
            else if (Page.User.IsInRole("UserCofre"))
            {
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

                var lojaList = user.GetLockCofres.Select(c => c.cod_loja).ToList();

                dsTodosGroup = new List<TreeListDataSource> { new TreeListDataSource { id = "T0", nome = "Todos", parentId = "" } };

                dsRedeGroup = dsLojaClienteRedeView.Where(p => lojaList.Contains(p.cod_loja)).GroupBy(x => new { idRede = "R" + x.id_rede.ToString(), nomeRede = x.nome_rede }).Select(y => new TreeListDataSource() { id = y.Key.idRede, parentId = "", nome = y.Key.nomeRede }).ToList();

                dsClienteGroup = dsLojaClienteRedeView.Where(p => lojaList.Contains(p.cod_loja)).GroupBy(x => new { idCliente = "C" + x.id_cliente.ToString(), nomeCliente = x.nome_cliente, idRede = x.id_rede }).Select(y => new TreeListDataSource() { id = y.Key.idCliente, parentId = "R" + y.Key.idRede.ToString(), nome = y.Key.nomeCliente }).ToList();

                dsLojaGroup = dsLojaClienteRedeView.Where(p => lojaList.Contains(p.cod_loja)).GroupBy(x => new { idLoja = "L" + x.id_loja.ToString(), nomeLoja = x.nome_loja, idCliente = x.id_cliente }).Select(y => new TreeListDataSource() { id = y.Key.idLoja, parentId = "C" + y.Key.idCliente.ToString(), nome = y.Key.nomeLoja }).ToList();
            }
            else
            {
                dsTodosGroup = new List<TreeListDataSource> { new TreeListDataSource { id = "T0", nome = "Todos", parentId = "" } };

                dsRedeGroup = dsLojaClienteRedeView.GroupBy(x => new { idRede = "R" + x.id_rede.ToString(), nomeRede = x.nome_rede }).Select(y => new TreeListDataSource() { id = y.Key.idRede, parentId = "T0", nome = y.Key.nomeRede }).ToList();

                dsClienteGroup = dsLojaClienteRedeView.GroupBy(x => new { idCliente = "C" + x.id_cliente.ToString(), nomeCliente = x.nome_cliente, idRede = x.id_rede }).Select(y => new TreeListDataSource() { id = y.Key.idCliente, parentId = "R" + y.Key.idRede.ToString(), nome = y.Key.nomeCliente }).ToList();

                dsLojaGroup = dsLojaClienteRedeView.GroupBy(x => new { idLoja = "L" + x.id_loja.ToString(), nomeLoja = x.nome_loja, idCliente = x.id_cliente }).Select(y => new TreeListDataSource() { id = y.Key.idLoja, parentId = "C" + y.Key.idCliente.ToString(), nome = y.Key.nomeLoja }).ToList();
            }
            
            List<TreeListDataSource> dsTreeList = dsTodosGroup.Concat(dsRedeGroup).Concat(dsClienteGroup).Concat(dsLojaGroup).ToList();

            ASPxTreeList1.DataSource = dsTreeList;
        }

        private class TreeListDataSource
        {
            public string id { get; set; }
            public string parentId { get; set; }
            public string nome { get; set; }
        }

        protected void ASPxTreeList1_DataBound(object sender, EventArgs e)
        {
            ASPxTreeList list = sender as ASPxTreeList;

            if (!IsPostBack)
            {
                if (Session["selectedLojas"] != null)
                {
                    var selectedLojas = (List<long>)Session["selectedLojas"];
                    var selectedKeys = selectedLojas.Select(x => "L" + x.ToString());

                    TreeListNodeIterator iterator = list.CreateNodeIterator();
                    TreeListNode node;
                    while (true)
                    {
                        node = iterator.GetNext();
                        if (node == null) break;

                        if (selectedKeys.Contains(node.Key))
                        {
                            node.Selected = true;
                        }
                    }
                }

            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            var selectedLojas = ASPxTreeList1.GetSelectedNodes().Where(k => k.Key.StartsWith("L")).Select(x => Convert.ToInt64(x.Key.Substring(1))).ToList();

            Session["selectedLojas"] = selectedLojas;

            var dateStart = new DateTime(deStart.Date.Year, deStart.Date.Month, deStart.Date.Day, teStart.DateTime.Hour, teStart.DateTime.Minute, teStart.DateTime.Second);
            var dateEnd = new DateTime(deEnd.Date.Year, deEnd.Date.Month, deEnd.Date.Day, teEnd.DateTime.Hour, teEnd.DateTime.Minute, teEnd.DateTime.Second);

            Session["dateStart"] = dateStart;
            Session["dateEnd"] = dateEnd;

            //call the content page method to rebind the data and refresh the update panel.
            contentCallEvent?.Invoke(this, EventArgs.Empty);
        }

        //protected void ASPxButton2_Click(object sender, EventArgs e)
        //{
        //    if (ASPxButton2.Text == "Selecionar tudo")
        //    {
        //        ASPxTreeList1.SelectAll();
        //        ASPxButton2.Text = "Desmarcar tudo";
        //    } 
        //    else
        //    {
        //        ASPxTreeList1.UnselectAll();
        //        ASPxButton2.Text = "Selecionar tudo";
        //    }
        //}

        public event EventHandler contentCallEvent;
    }
}