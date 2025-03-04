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
            string item = Request.QueryString["item"] ?? "TTU-01APQ"; // Default value if not provided
            string dataInicial = Request.QueryString["dataInicial"] ?? "2025-02-21"; // Default value
            string dataFinal = Request.QueryString["dataFinal"] ?? "2025-02-22"; // Default value

            var objReport = new repSalasTempHR();
            objReport.Parameters[0].Value = item;
            objReport.Parameters[1].Value = dataInicial;
            objReport.Parameters[2].Value = dataFinal;

            //var reportName = "JaSaudeTeste";
            //objReport.ExportToPdf(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\" + reportName + ".pdf");

            using (MemoryStream ms = new MemoryStream())
            {
                objReport.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                WriteDocumentToResponse(ms.ToArray(), "pdf", true, "JaSaudeSalasTempHR.pdf");
            }
        }
    }
}