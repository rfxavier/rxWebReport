using DevExpress.XtraPrinting;
using rxWebReport.reportClasses;
using System;
using System.IO;

namespace rxWebReport.frmAgyliti.JaSaude
{
    public partial class relSalasTempHR : System.Web.UI.Page
    {
        void WriteDocumentToResponse(byte[] documentData, string format, bool isInline, string fileName)
        {
            string contentType;
            string disposition = (isInline) ? "inline" : "attachment";

            switch (format.ToLower())
            {
                case "xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "mht":
                    contentType = "message/rfc822";
                    break;
                case "html":
                    contentType = "text/html";
                    break;
                case "txt":
                case "csv":
                    contentType = "text/plain";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                default:
                    contentType = String.Format("application/{0}", format);
                    break;
            }

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", disposition, fileName));
            Response.BinaryWrite(documentData);
            Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string itemQuery = Request.QueryString["item"] ?? "TTU-01APQ"; // Default value if not provided
            string dataInicial = Request.QueryString["dataInicial"] ?? "2025-02-21"; // Default value
            string dataFinal = Request.QueryString["dataFinal"] ?? "2025-02-22"; // Default value

            string[] items = itemQuery.Split(','); // Split items into an array

            repSalasTempHR masterReport = null;

            foreach (var item in items)
            {
                var objReport = new repSalasTempHR();
                objReport.Parameters[0].Value = item;
                objReport.Parameters[1].Value = dataInicial;
                objReport.Parameters[2].Value = dataFinal;

                var chart = (DevExpress.XtraReports.UI.XRChart)objReport.FindControl("chart2", true);
                if (chart != null)
                {
                    chart.Series[0].Name = item + " ºC";
                    chart.Series[1].Name = item + " %HR";
                }

                objReport.CreateDocument(); // Generate the report document

                if (masterReport == null)
                {
                    masterReport = objReport;
                }
                else
                {
                    masterReport.Pages.AddRange(objReport.Pages);
                }
            }

            if (masterReport != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    masterReport.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    WriteDocumentToResponse(ms.ToArray(), "pdf", true, "JaSaudeSalasTempHR.pdf");
                }
            }
        }
    }
}