using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using rxWebReport.reportClasses;
using System;
using System.Drawing;
using System.IO;

namespace rxWebReport.frmAgyliti.Bacio
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
            string formatoQuery = Request.QueryString["formato"] ?? "PDF"; // Default value if not provided
            string rawDataInicial = Request.QueryString["dataInicial"];
            string dataInicial;

            if (!string.IsNullOrWhiteSpace(rawDataInicial) &&
                DateTime.TryParseExact(rawDataInicial, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDataInicial))
            {
                dataInicial = rawDataInicial + " 00:00:00";
            }
            else
            {
                dataInicial = rawDataInicial ?? "2025-02-22 00:00:00";
            }

            string rawDataFinal = Request.QueryString["dataFinal"];
            string dataFinal;

            if (!string.IsNullOrWhiteSpace(rawDataFinal) &&
                DateTime.TryParseExact(rawDataFinal, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime parsedDataFinal))
            {
                dataFinal = rawDataFinal + " 23:59:59";
            }
            else
            {
                dataFinal = rawDataFinal ?? "2025-02-22 23:59:59"; // Default value
            }
            string triggerTag = Request.QueryString["triggertag"];
            string medida = Request.QueryString["medida"] ?? "Pressão"; // Default value if not provided
            string unidade = Request.QueryString["unidade"] ?? "psi"; // Default value if not provided
            decimal limiteInferior = Convert.ToDecimal(Request.QueryString["limiteinferior"]); 
            decimal limiteSuperior= Convert.ToDecimal(Request.QueryString["limitesuperior"]); // Default value if not provided

            string[] items = itemQuery.Split(','); // Split items into an array

            string logoFilename = Request.QueryString["logo"] ?? "LogoAux.png"; // default logo if not provided

            string logosFolder = Server.MapPath("~/Content/Images/");
            string logoPath = Path.Combine(logosFolder, logoFilename);

            logoFilename = Path.GetFileName(logoFilename); // Removes any path parts

            Image logoImage = null;

            if (File.Exists(logoPath))
            {
                logoImage = Image.FromFile(logoPath);
            }
            else
            {
                // Optionally, load a fallback image
                string fallbackPath = Path.Combine(logosFolder, "LogoAux.png");
                if (File.Exists(fallbackPath))
                {
                    logoImage = Image.FromFile(fallbackPath);
                }
            }

            repDadosSensor masterReport = null;

            foreach (var item in items)
            {
                var objReport = new repDadosSensor();
                objReport.Parameters["parRepGroupname"].Value = grupo;
                objReport.Parameters["parRepHostname"].Value = host;
                objReport.Parameters["parRepItem"].Value = item;
                objReport.Parameters["parRepInitialDate"].Value = dataInicial;
                objReport.Parameters["parRepFinalDate"].Value = dataFinal;
                objReport.Parameters["parRepTriggerTag"].Value = triggerTag;
                objReport.Parameters["parRepMedida"].Value = medida;
                objReport.Parameters["parRepLimiteInferior"].Value = limiteInferior;
                objReport.Parameters["parRepLimiteSuperior"].Value = limiteSuperior;

                var chart = (DevExpress.XtraReports.UI.XRChart)objReport.FindControl("chart2", true);
                if (chart != null)
                {
                    chart.Series[0].Name = item + $" {unidade}";
                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = limiteInferior;
                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = limiteSuperior;
                }

                if (logoImage != null)
                {
                    var pictureBox = (DevExpress.XtraReports.UI.XRPictureBox)objReport.FindControl("PictureBox1", true);
                    if (pictureBox != null)
                    {
                        pictureBox.Image = logoImage;
                    }
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
                    if (formatoQuery == "PDF")
                    {
                        masterReport.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = false });
                        WriteDocumentToResponse(ms.ToArray(), "pdf", true, "DadosSensor.pdf");
                    } else if (formatoQuery == "CSV") 
                    {
                        masterReport.ExportToXlsx(ms, new XlsxExportOptions() { ExportMode = XlsxExportMode.SingleFilePageByPage });
                        WriteDocumentToResponse(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", false, "DadosSensor.xlsx");
                    }
                }
            }
        }
    }
}