using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using rxWebReport.reportClasses;
using System;
using System.IO;
using System.Web;
using static rxWebReport.dataObjClasses.dsJaSaude;

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

                var labelLimiteInferior = (DevExpress.XtraReports.UI.XRLabel)objReport.FindControl("labelLimiteInferior", true);
                var labelLimiteSuperior = (DevExpress.XtraReports.UI.XRLabel)objReport.FindControl("labelLimiteSuperior", true);

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
                        labelLimiteSuperior.ExpressionBindings.Clear();
                        labelLimiteSuperior.Visible = false;

                    }
                    else
                    {
                        if (item.EndsWith("Temperatura", StringComparison.OrdinalIgnoreCase))
                        {
                            chart.Series[0].Name = item + " ºC";
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Text = "15,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                            if (item.StartsWith("REG-01APQ") || item.StartsWith("TTU-01APQ"))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 30;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "30,0";

                                //calcTempValueColor
                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 15, 'Red', Iif([Value] > 30, 'Red', 'Black'))";
                            }
                            else
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 25;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "25,0";

                                //calcTempValueColor
                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 15, 'Red', Iif([Value] > 25, 'Red', 'Black'))";
                            }

                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.Auto = false;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.AutoSideMargins = false;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.SideMarginsValue = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.StartSideMargin = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.MinValue = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.MaxValue = 50;
                        }
                        else if (item.EndsWith("Umidade", StringComparison.OrdinalIgnoreCase))
                        {
                            var label = item.Contains("Humidade")
                                ? item.Replace("Humidade", "Umidade")
                                : item;

                            //calcParRepItemPrefix
                            objReport.CalculatedFields[9].Expression = $"'{label}'";

                            chart.Series[0].Name = label + " %HR";
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = false;

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                            if (item.StartsWith("TTU-03BIPE"))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 75;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "75,0";

                                //calcHumidityValueColor
                                objReport.CalculatedFields[5].Expression = "Iif([Value] > 75, 'Red', 'Black')";
                            }
                            else if (item.StartsWith("TTU-01BIPE") || item.StartsWith("TTU-02BIPE") || item.StartsWith("TTU-04BIPE") || item.StartsWith("TTU-05BIPE") || item.StartsWith("TTU-06BIPE"))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = false;

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 80;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "80,0";

                                //calcHumidityValueColor
                                objReport.CalculatedFields[5].Expression = "Iif([Value] > 80, 'Red', 'Black')";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Title.Text = "Limite";
                            }
                            else if (item.StartsWith("TTU-03BIPE"))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = false;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 75;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "75,0";

                                //calcHumidityValueColor
                                objReport.CalculatedFields[5].Expression = "Iif([Value] > 75, 'Red', 'Black')";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Title.Text = "Limite";
                            }
                            else if (item.StartsWith("REG-01APQ") || item.StartsWith("TTU-01APQ"))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.WholeRange.AutoSideMargins = false;
                                ((XYDiagram)chart.Diagram).AxisY.WholeRange.SideMarginsValue = 0;
                                ((XYDiagram)chart.Diagram).AxisY.WholeRange.StartSideMargin = 0;
                                ((XYDiagram)chart.Diagram).AxisY.WholeRange.MinValue = 0;
                                ((XYDiagram)chart.Diagram).AxisY.WholeRange.MaxValue = 100;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = false;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = false;

                                //calcHumidityValueColor
                                objReport.CalculatedFields[5].Expression = "'Black'";
                            }
                            else
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 80;

                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "80,0";

                                //calcHumidityValueColor
                                objReport.CalculatedFields[5].Expression = "Iif([Value] > 80, 'Red', 'Black')";
                            }
                        }
                    }
                }

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