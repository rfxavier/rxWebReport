using System;
using System.IO;
using System.Web;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using rxWebReport.reportClasses;

namespace rxWebReport.frmAgyliti.JaSaude
{
    public partial class DownloadSalasTempHR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string itemQuery = Request.QueryString["item"] ?? "REG-01APQ-Umidade";

            string dataInicial = NormalizeDate(
                Request.QueryString["dataInicial"],
                "2026-05-10 00:00:00",
                true
            );

            string dataFinal = NormalizeDate(
                Request.QueryString["dataFinal"],
                "2026-05-10 23:59:59",
                false
            );

            byte[] pdfBytes = GeneratePdf(itemQuery, dataInicial, dataFinal);

            string fileName = $"JaSaudeSalasTempHR_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private static string NormalizeDate(string rawValue, string defaultValue, bool startOfDay)
        {
            if (!string.IsNullOrWhiteSpace(rawValue) &&
                DateTime.TryParseExact(
                    rawValue,
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDate))
            {
                return rawValue + (startOfDay ? " 00:00:00" : " 23:59:59");
            }

            return rawValue ?? defaultValue;
        }

        private static byte[] GeneratePdf(string itemQuery, string dataInicial, string dataFinal)
        {
            string[] items = itemQuery.Split(',');

            repSalasTempHR masterReport = null;

            foreach (string rawItem in items)
            {
                string item = rawItem.Trim();

                var objReport = new repSalasTempHR();

                objReport.Parameters[0].Value = item;
                objReport.Parameters[1].Value = dataInicial;
                objReport.Parameters[2].Value = dataFinal;

                // Put your existing chart/rule customization here.
                // For the first test, keep it simple and copy the same block
                // from relSalasTempHR.aspx.cs.

                objReport.CreateDocument();

                if (masterReport == null)
                    masterReport = objReport;
                else
                    masterReport.Pages.AddRange(objReport.Pages);
            }

            if (masterReport == null)
                throw new InvalidOperationException("No report was generated.");

            using (var ms = new MemoryStream())
            {
                masterReport.ExportToPdf(
                    ms,
                    new PdfExportOptions
                    {
                        ShowPrintDialogOnOpen = false
                    });

                return ms.ToArray();
            }
        }
    }
}