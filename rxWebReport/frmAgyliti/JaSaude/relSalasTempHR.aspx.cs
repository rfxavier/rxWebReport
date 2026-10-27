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

                var labelLimiteInferior = (DevExpress.XtraReports.UI.XRLabel)objReport.FindControl("labelLimiteInferior", true);
                var labelLimiteSuperior = (DevExpress.XtraReports.UI.XRLabel)objReport.FindControl("labelLimiteSuperior", true);

                var chart = (DevExpress.XtraReports.UI.XRChart)objReport.FindControl("chart2", true);
                if (chart != null)
                {
                    if (item.EndsWith("BIPE", StringComparison.OrdinalIgnoreCase) || item.StartsWith("TDP", StringComparison.OrdinalIgnoreCase))
                    {
                        chart.Series[0].Name = item + " Dif. Pressão";

                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;

                        var (_, acceptanceValue) = SensorHelper.GetAcceptanceCriteria(item);
                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = acceptanceValue;

                        ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                        labelLimiteSuperior.ExpressionBindings.Clear();
                        labelLimiteSuperior.Visible = false;

                        // Section 4.1-4.7 pressure references.
                        if (item == "TDP-01LI" ||
                            item == "TDP-02BIIAC" ||
                            item == "TDP-05ANS" ||
                            item == "TDP-07APN" ||
                            item == "TDP-10APN" ||
                            item == "TDP-11APN" ||
                            item == "TDP-14APN" ||
                            item == "TDP-15APN")
                        {
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 10;
                            labelLimiteInferior.Text = "10,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                            labelLimiteSuperior.ExpressionBindings.Clear();
                            labelLimiteSuperior.Visible = false;

                            objReport.CalculatedFields[2].Expression = "Iif([Value] < 10, 'Red', 'Black')";
                        }
                        else if (item == "TDP-02LI" ||
                            item == "TDP-03LI" ||
                            item == "TDP-05LI" ||
                            item == "TDP-06LI" ||
                            item == "TDP-07LI" ||
                            item == "TDP-08LI" ||
                            item == "TDP-09LI" ||
                            item == "TDP-11LI" ||
                            item == "TDP-12LI" ||
                            item == "TDP-13LI")
                        {
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 5;
                            labelLimiteInferior.Text = "5,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                            labelLimiteSuperior.ExpressionBindings.Clear();
                            labelLimiteSuperior.Visible = false;

                            objReport.CalculatedFields[2].Expression = "Iif([Value] < 5, 'Red', 'Black')";
                        }
                        else if (item == "TDP-04LI" ||
                            item == "TDP-10LI" ||
                            item == "TDP-01BIIL1" ||
                            item == "TDP-02BIIL1" ||
                            item == "TDP-03BIIL1" ||
                            item == "TDP-04BIIL1" ||
                            item == "TDP-06BIIL1" ||
                            item == "TDP-08BIIL1" ||
                            item == "TDP-01BIIL2" ||
                            item == "TDP-02BIIL2" ||
                            item == "TDP-03BIIL2" ||
                            item == "TDP-04BIIL2" ||
                            item == "TDP-06BIIL2" ||
                            item == "TDP-08BIIL2" ||
                            item == "TDP-01BIIL3" ||
                            item == "TDP-02BIIL3" ||
                            item == "TDP-03BIIL3" ||
                            item == "TDP-04BIIL3" ||
                            item == "TDP-05BIIL3" ||
                            item == "TDP-06BIIL3" ||
                            item == "TDP-07BIIL3" ||
                            item == "TDP-01BIIAC" ||
                            item == "TDP-02ANS" ||
                            item == "TDP-03ANS" ||
                            item == "TDP-04ANS" ||
                            item == "TDP-06ANS" ||
                            item == "TDP-07ANS" ||
                            item == "TDP-03APN" ||
                            item == "TDP-04APN" ||
                            item == "TDP-05APN" ||
                            item == "TDP-06APN" ||
                            item == "TDP-09APN" ||
                            item == "TDP-12APN" ||
                            item == "TDP-13APN")
                        {
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                            labelLimiteInferior.Text = "15,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                            labelLimiteSuperior.ExpressionBindings.Clear();
                            labelLimiteSuperior.Visible = false;

                            objReport.CalculatedFields[2].Expression = "Iif([Value] < 15, 'Red', 'Black')";
                        }
                        else if (item == "TDP-05BIIL1" ||
                            item == "TDP-07BIIL1" ||
                            item == "TDP-05BIIL2" ||
                            item == "TDP-07BIIL2" ||
                            item == "TDP-08BIIL3")
                        {
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 20;
                            labelLimiteInferior.Text = "20,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                            labelLimiteSuperior.ExpressionBindings.Clear();
                            labelLimiteSuperior.Visible = false;

                            objReport.CalculatedFields[2].Expression = "Iif([Value] < 20, 'Red', 'Black')";
                        }
                        else if (item == "TDP-02APN" ||
                            item == "TDP-08APN")
                        {
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                            labelLimiteInferior.ExpressionBindings.Clear();
                            labelLimiteInferior.Visible = true;
                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 0;
                            labelLimiteInferior.Text = "0,0";

                            ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                            labelLimiteSuperior.ExpressionBindings.Clear();
                            labelLimiteSuperior.Visible = false;

                            // Only a 0 Pa reference is specified; no conformity tolerance is defined.
                            objReport.CalculatedFields[2].Expression = "'Black'";
                        }

                    }
                    else
                    {
                        if (item.EndsWith("Temperatura", StringComparison.OrdinalIgnoreCase) || item.StartsWith("CFR", StringComparison.OrdinalIgnoreCase))
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

                            // Section 4.1-4.7 temperature limits.
                            if (item.StartsWith("TTU-01LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-06LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-07LI", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                                labelLimiteInferior.Text = "15,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 25;
                                labelLimiteSuperior.Text = "25,0";

                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 15, 'Red', Iif([Value] > 25, 'Red', 'Black'))";
                            }
                            else if (item.StartsWith("TTU-02LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-05LI", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                                labelLimiteInferior.Text = "15,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 22;
                                labelLimiteSuperior.Text = "22,0";

                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 15, 'Red', Iif([Value] > 22, 'Red', 'Black'))";
                            }
                            else if (item.StartsWith("TTU-08LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIAC", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 15;
                                labelLimiteInferior.Text = "15,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 30;
                                labelLimiteSuperior.Text = "30,0";

                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 15, 'Red', Iif([Value] > 30, 'Red', 'Black'))";
                            }
                            else if (item.StartsWith("TTU-02ANS", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02APN", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 20;
                                labelLimiteInferior.Text = "20,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 24;
                                labelLimiteSuperior.Text = "24,0";

                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 20, 'Red', Iif([Value] > 24, 'Red', 'Black'))";
                            }
                            else if (item == "CFR-01UEA")
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 2;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Text = "2,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 8;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "8,0";

                                //calcTempValueColor
                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 2, 'Red', Iif([Value] > 8, 'Red', 'Black'))";
                            }
                            else if (item == "CCL-01UEA Temperatura")
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 28;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Text = "28,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 32;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "32,0";

                                //calcTempValueColor
                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 28, 'Red', Iif([Value] > 32, 'Red', 'Black'))";
                            }
                            else if (item == "CCL-02UEA Temperatura")
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 38;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Text = "38,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 42;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Text = "42,0";

                                //calcTempValueColor
                                objReport.CalculatedFields[4].Expression = "Iif([Value] < 38, 'Red', Iif([Value] > 42, 'Red', 'Black'))";
                            }

                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.Auto = false;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.AutoSideMargins = false;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.SideMarginsValue = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.StartSideMargin = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.MinValue = 0;
                            ((XYDiagram)chart.Diagram).AxisY.WholeRange.MaxValue = 50;
                        }
                        else if (item.EndsWith("Umidade", StringComparison.OrdinalIgnoreCase) || item.EndsWith("Humidade", StringComparison.OrdinalIgnoreCase) || item.StartsWith("CCL", StringComparison.OrdinalIgnoreCase))
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
                            // Section 4.1-4.7 humidity limits (informative items have none).
                            if (item.StartsWith("TTU-01LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-06LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-07LI", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 30;
                                labelLimiteInferior.Text = "30,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 75;
                                labelLimiteSuperior.Text = "75,0";

                                objReport.CalculatedFields[5].Expression = "Iif([Value] < 30, 'Red', Iif([Value] > 75, 'Red', 'Black'))";
                            }
                            else if (item.StartsWith("TTU-02LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-05LI", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 30;
                                labelLimiteInferior.Text = "30,0";

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 80;
                                labelLimiteSuperior.Text = "80,0";

                                objReport.CalculatedFields[5].Expression = "Iif([Value] < 30, 'Red', Iif([Value] > 80, 'Red', 'Black'))";
                            }
                            else if (item.StartsWith("TTU-02ANS", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02APN", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = false;

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = true;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = true;
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 65;
                                labelLimiteSuperior.Text = "65,0";

                                objReport.CalculatedFields[5].Expression = "Iif([Value] >= 65, 'Red', 'Black')";
                            }
                            else if (item.StartsWith("TTU-08LI", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL1", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL2", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-03BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-04BIIL3", StringComparison.OrdinalIgnoreCase) ||
                                item.StartsWith("TTU-02BIIAC", StringComparison.OrdinalIgnoreCase))
                            {
                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = false;
                                labelLimiteInferior.ExpressionBindings.Clear();
                                labelLimiteInferior.Visible = false;

                                ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].Visible = false;
                                labelLimiteSuperior.ExpressionBindings.Clear();
                                labelLimiteSuperior.Visible = false;

                                objReport.CalculatedFields[5].Expression = "'Black'";
                            }
                            else if (item.StartsWith("TTU-03BIPE"))
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

                                if (item == "CCL-01UEA Umidade")
                                {
                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                    labelLimiteInferior.ExpressionBindings.Clear();
                                    labelLimiteInferior.Visible = true;

                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 60;
                                    labelLimiteInferior.ExpressionBindings.Clear();
                                    labelLimiteInferior.Text = "60,0";

                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 70;
                                    labelLimiteSuperior.ExpressionBindings.Clear();
                                    labelLimiteSuperior.Text = "70,0";

                                    //calcTempValueColor
                                    objReport.CalculatedFields[5].Expression = "Iif([Value] < 60, 'Red', Iif([Value] > 70, 'Red', 'Black'))";
                                }
                                else if (item == "CCL-02UEA Umidade")
                                {
                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].Visible = true;
                                    labelLimiteInferior.ExpressionBindings.Clear();
                                    labelLimiteInferior.Visible = true;

                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[0].AxisValue = 70;
                                    labelLimiteInferior.ExpressionBindings.Clear();
                                    labelLimiteInferior.Text = "70,0";

                                    ((XYDiagram)chart.Diagram).AxisY.ConstantLines[1].AxisValue = 80;
                                    labelLimiteSuperior.ExpressionBindings.Clear();
                                    labelLimiteSuperior.Text = "80,0";

                                    //calcTempValueColor
                                    objReport.CalculatedFields[5].Expression = "Iif([Value] < 70, 'Red', Iif([Value] > 80, 'Red', 'Black'))";
                                }

                            }
                        }
                    }
                }

                objReport.ConfigureReadings(item, dataInicial, dataFinal);
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
