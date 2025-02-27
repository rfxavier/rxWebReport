using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace rxWebReport.frmAgyliti.GetLock.cnRelatorios
{
    public partial class cnGridDepositosUsuario : System.Web.UI.Page
    {
        public class DepositosUsuario
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string user_lastname { get; set; }
            public Nullable<long> data_currency_bill_2 { get; set; }
            public Nullable<long> data_currency_bill_5 { get; set; }
            public Nullable<long> data_currency_bill_10 { get; set; }
            public Nullable<long> data_currency_bill_20 { get; set; }
            public Nullable<long> data_currency_bill_50 { get; set; }
            public Nullable<long> data_currency_bill_100 { get; set; }
            public Nullable<long> data_currency_bill_200 { get; set; }
            public Nullable<decimal> data_currency_total { get; set; }
        }

        string query;
        object ds;

        public cnGridDepositosUsuario()
        {
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's contentCallEvent event
            Master.contentCallEvent += new EventHandler(Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DateTime dateStart;
            DateTime dateEnd;

            if (Session["dateStart"] != null)
            {
                dateStart = (DateTime)Session["dateStart"];
            }
            else
            {
                dateStart = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            }

            if (Session["dateEnd"] != null)
            {
                dateEnd = (DateTime)Session["dateEnd"];
            }
            else
            {
                dateEnd = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            }

            if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
            {
                var selectedLojas = (List<long>)Session["selectedLojas"];

                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime between '{dateStart:yyyy-MM-dd HH:mm}' and '{dateEnd:yyyy-MM-dd HH:mm}' and l.id in ({string.Join(",", selectedLojas)}) group by m.user_id";
            }
            else if (Session["selectedLojas"] != null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
            {
                var selectedLojas = (List<long>)Session["selectedLojas"];

                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime >= '{dateStart:yyyy-MM-dd HH:mm}' and l.id in ({string.Join(",", selectedLojas)}) group by m.user_id";
            }
            else if (Session["selectedLojas"] != null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
            {
                var selectedLojas = (List<long>)Session["selectedLojas"];

                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime <= '{dateEnd:yyyy-MM-dd HH:mm}' and l.id in ({string.Join(",", selectedLojas)}) group by m.user_id";
            }
            else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] != null))
            {
                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime between '{dateStart:yyyy-MM-dd HH:mm}' and '{dateEnd:yyyy-MM-dd HH:mm}' group by m.user_id";
            }
            else if (Session["selectedLojas"] == null && (Session["dateStart"] != null) && (Session["dateEnd"] == null))
            {
                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime >= '{dateStart:yyyy-MM-dd HH:mm}' group by m.user_id";
            }
            else if (Session["selectedLojas"] == null && (Session["dateStart"] == null) && (Session["dateEnd"] != null))
            {
                query = $"SELECT m.user_id, MAX(m.user_name) user_name, MAX(m.user_lastname) user_lastname, SUM(m.data_currency_bill_2) data_currency_bill_2, SUM(m.data_currency_bill_5) data_currency_bill_5, SUM(m.data_currency_bill_10) data_currency_bill_10, SUM(m.data_currency_bill_20) data_currency_bill_20, SUM(m.data_currency_bill_50) data_currency_bill_50, SUM(m.data_currency_bill_100) data_currency_bill_100, SUM(m.data_currency_bill_200) data_currency_bill_200, SUM(m.data_currency_total) data_currency_total FROM message m LEFT OUTER JOIN dbo.loja AS l ON m.cod_loja = l.cod_loja WHERE m.data_type in ('1', '2', '3', '4') and m.data_tmst_end_datetime <= '{dateEnd:yyyy-MM-dd HH:mm}' group by m.user_id";
            }

            if (query != null)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ds = ctx.Database.SqlQuery<DepositosUsuario>(query).ToList();
                }
            }

            ASPxGridView1.DataSource = ds;
        }

        protected void ASPxGridView1_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            decimal b2 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_2"));
            decimal b5 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_5"));
            decimal b10 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_10"));
            decimal b20 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_20"));
            decimal b50 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_50"));
            decimal b100 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_100"));
            decimal b200 = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_bill_200"));
            decimal btotal = Convert.ToInt64(e.GetListSourceFieldValue("data_currency_total"));

            if (e.Column.FieldName == "TotalCount")
            {
                e.Value = b2 + b5 + b10 + b20 + b50 + b100 + b200;
            }

            if (e.Column.FieldName == "TotalValue")
            {
                if (btotal > 0)
                {
                    e.Value = btotal;
                }
                else
                {
                    e.Value = b2 * 2 + b5 * 5 + b10 * 10 + b20 * 20 + b50 * 50 + b100 * 100 + b200 * 200;
                }
            }
        }

    }
}