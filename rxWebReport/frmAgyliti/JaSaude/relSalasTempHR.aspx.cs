using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using rxWebReport.reportClasses;
using System;
using System.IO;
using static rxWebReport.dataObjClasses.dsJaSaude;

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
            string itemQuery = Request.QueryString["item"] ?? "TTU-02BIPE-Humidade"; // Default value if not provided
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
                    if (item.EndsWith("BIPE", StringComparison.OrdinalIgnoreCase))
                    {
                        chart.Series[0].Name = item + " Dif. Pressão";

                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;

                        var (_, acceptanceValue) = SensorHelper.GetAcceptanceCriteria(item);
                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = acceptanceValue;

                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                    }
                    else
                    {
                        if (item.EndsWith("Temperatura", StringComparison.OrdinalIgnoreCase))
                        {
                            chart.Series[0].Name = item + " ºC";
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 30;

                        }
                        else if (item.EndsWith("Humidade", StringComparison.OrdinalIgnoreCase))
                        {
                            chart.Series[0].Name = item + " %HR";
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 65;
                        }
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
                    masterReport.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = false });
                    WriteDocumentToResponse(ms.ToArray(), "pdf", true, "JaSaudeSalasTempHR.pdf");
                }
            }
        }
    }
}