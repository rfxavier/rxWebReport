using DevExpress.XtraPrinting;
using rxWebReport.reportClasses;
using System;
using System.IO;
using static rxWebReport.dataObjClasses.dsMicroset;

namespace rxWebReport.frmAgyliti.DadosSensor
{
    public partial class relDadosSensor : System.Web.UI.Page
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
            string grupo = Request.QueryString["grupo"] ?? "IoT | JA Saude Animal"; // Default value if not provided
            string host = Request.QueryString["host"] ?? "JASAUDE - FieldLogger"; // Default value if not provided
            string itemQuery = Request.QueryString["item"] ?? "TDP-01BIPE"; // Default value if not provided
            string dataInicial = Request.QueryString["dataInicial"] ?? "2025-06-21"; // Default value
            string dataFinal = Request.QueryString["dataFinal"] ?? "2025-06-22"; // Default value

            string[] items = itemQuery.Split(','); // Split items into an array

            repDadosSensor masterReport = null;

            foreach (var item in items)
            {
                var objReport = new repDadosSensor();
                objReport.Parameters["parRepGroupname"].Value = grupo;
                objReport.Parameters["parRepHostname"].Value = host;
                objReport.Parameters["parRepItem"].Value = item;
                objReport.Parameters["parRepInitialDate"].Value = dataInicial;
                objReport.Parameters["parRepFinalDate"].Value = dataFinal;

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
                    masterReport.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = false });
                    WriteDocumentToResponse(ms.ToArray(), "pdf", true, "DadosSensor.pdf");
                }
            }

        }
    }
}