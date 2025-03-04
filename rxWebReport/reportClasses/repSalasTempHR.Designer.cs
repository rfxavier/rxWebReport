
namespace rxWebReport.reportClasses
{
    partial class repSalasTempHR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter9 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter10 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter11 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter1 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter2 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter3 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter4 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter5 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter6 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter7 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter8 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.chart2 = new DevExpress.XtraReports.UI.XRChart();
            this.objectDataSource3 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.parRepItemPrefix = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepInitialDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepFinalDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 46.875F;
            this.TopMargin.Name = "TopMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label5,
            this.label4,
            this.label3,
            this.label2,
            this.label1});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.chart2});
            this.ReportHeader.HeightF = 567.7083F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // label5
            // 
            this.label5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ValueTemperature]")});
            this.label5.LocationFloat = new DevExpress.Utils.PointFloat(683.3333F, 0F);
            this.label5.Multiline = true;
            this.label5.Name = "label5";
            this.label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label5.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.label5.Text = "label5";
            this.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ValueHumidity]")});
            this.label4.LocationFloat = new DevExpress.Utils.PointFloat(523.9583F, 0F);
            this.label4.Multiline = true;
            this.label4.Name = "label4";
            this.label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label4.SizeF = new System.Drawing.SizeF(125F, 23F);
            this.label4.Text = "label4";
            this.label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SensorDate]")});
            this.label3.LocationFloat = new DevExpress.Utils.PointFloat(230.2083F, 0F);
            this.label3.Multiline = true;
            this.label3.Name = "label3";
            this.label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label3.SizeF = new System.Drawing.SizeF(273.9583F, 23F);
            this.label3.Text = "label3";
            this.label3.TextFormatString = "{0:MM/dd/yy HH:mm}";
            // 
            // label2
            // 
            this.label2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Item]")});
            this.label2.LocationFloat = new DevExpress.Utils.PointFloat(114.5833F, 0F);
            this.label2.Multiline = true;
            this.label2.Name = "label2";
            this.label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Hostname]")});
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Multiline = true;
            this.label1.Name = "label1";
            this.label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label1.Text = "label1";
            // 
            // chart2
            // 
            this.chart2.BorderColor = System.Drawing.Color.Black;
            this.chart2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Hour;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chart2.Diagram = xyDiagram1;
            this.chart2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.chart2.Name = "chart2";
            series1.ArgumentDataMember = "SensorDate";
            series1.DataSource = this.objectDataSource1;
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "Value";
            series1.View = lineSeriesView1;
            series2.ArgumentDataMember = "SensorDate";
            series2.DataSource = this.objectDataSource2;
            series2.Name = "Series 2";
            series2.ValueDataMembersSerializable = "Value";
            lineSeriesView2.AxisYName = "Secondary AxisY 1";
            series2.View = lineSeriesView2;
            this.chart2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chart2.SizeF = new System.Drawing.SizeF(869.7916F, 530.2083F);
            // 
            // objectDataSource3
            // 
            this.objectDataSource3.DataMember = "GetDataPivoted";
            this.objectDataSource3.DataSource = typeof(rxWebReport.dataObjClasses.dsJaSaude);
            this.objectDataSource3.Name = "objectDataSource3";
            parameter9.Name = "ItemPrefix";
            parameter9.Type = typeof(DevExpress.DataAccess.Expression);
            parameter9.Value = new DevExpress.DataAccess.Expression("?parRepItemPrefix", typeof(string));
            parameter10.Name = "InitialDate";
            parameter10.Type = typeof(DevExpress.DataAccess.Expression);
            parameter10.Value = new DevExpress.DataAccess.Expression("?parRepInitialDate", typeof(string));
            parameter11.Name = "FinalDate";
            parameter11.Type = typeof(DevExpress.DataAccess.Expression);
            parameter11.Value = new DevExpress.DataAccess.Expression("?parRepFinalDate", typeof(string));
            this.objectDataSource3.Parameters.AddRange(new DevExpress.DataAccess.ObjectBinding.Parameter[] {
            parameter9,
            parameter10,
            parameter11});
            // 
            // parRepItemPrefix
            // 
            this.parRepItemPrefix.Name = "parRepItemPrefix";
            this.parRepItemPrefix.ValueInfo = "TTU-01APQ";
            this.parRepItemPrefix.Visible = false;
            // 
            // parRepInitialDate
            // 
            this.parRepInitialDate.Name = "parRepInitialDate";
            this.parRepInitialDate.ValueInfo = "2025-02-21";
            this.parRepInitialDate.Visible = false;
            // 
            // parRepFinalDate
            // 
            this.parRepFinalDate.Name = "parRepFinalDate";
            this.parRepFinalDate.ValueInfo = "2025-02-22";
            this.parRepFinalDate.Visible = false;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(rxWebReport.dataObjClasses.dsJaSaude);
            this.objectDataSource1.Name = "objectDataSource1";
            parameter1.Name = "ItemPrefix";
            parameter1.Type = typeof(DevExpress.DataAccess.Expression);
            parameter1.Value = new DevExpress.DataAccess.Expression("?parRepItemPrefix", typeof(string));
            parameter2.Name = "ValueType";
            parameter2.Type = typeof(DevExpress.DataAccess.Expression);
            parameter2.Value = new DevExpress.DataAccess.Expression("\'T\'", typeof(string));
            parameter3.Name = "InitialDate";
            parameter3.Type = typeof(DevExpress.DataAccess.Expression);
            parameter3.Value = new DevExpress.DataAccess.Expression("?parRepInitialDate", typeof(string));
            parameter4.Name = "FinalDate";
            parameter4.Type = typeof(DevExpress.DataAccess.Expression);
            parameter4.Value = new DevExpress.DataAccess.Expression("?parRepFinalDate", typeof(string));
            this.objectDataSource1.Parameters.AddRange(new DevExpress.DataAccess.ObjectBinding.Parameter[] {
            parameter1,
            parameter2,
            parameter3,
            parameter4});
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataMember = "GetData";
            this.objectDataSource2.DataSource = typeof(rxWebReport.dataObjClasses.dsJaSaude);
            this.objectDataSource2.Name = "objectDataSource2";
            parameter5.Name = "ItemPrefix";
            parameter5.Type = typeof(DevExpress.DataAccess.Expression);
            parameter5.Value = new DevExpress.DataAccess.Expression("?parRepItemPrefix", typeof(string));
            parameter6.Name = "ValueType";
            parameter6.Type = typeof(DevExpress.DataAccess.Expression);
            parameter6.Value = new DevExpress.DataAccess.Expression("\'H\'", typeof(string));
            parameter7.Name = "InitialDate";
            parameter7.Type = typeof(DevExpress.DataAccess.Expression);
            parameter7.Value = new DevExpress.DataAccess.Expression("?parRepInitialDate", typeof(string));
            parameter8.Name = "FinalDate";
            parameter8.Type = typeof(DevExpress.DataAccess.Expression);
            parameter8.Value = new DevExpress.DataAccess.Expression("?parRepFinalDate", typeof(string));
            this.objectDataSource2.Parameters.AddRange(new DevExpress.DataAccess.ObjectBinding.Parameter[] {
            parameter5,
            parameter6,
            parameter7,
            parameter8});
            // 
            // repSalasTempHR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.Detail,
            this.BottomMargin,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1,
            this.objectDataSource2,
            this.objectDataSource3});
            this.DataSource = this.objectDataSource3;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 47, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parRepItemPrefix,
            this.parRepInitialDate,
            this.parRepFinalDate});
            this.Version = "21.1";
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel label5;
        private DevExpress.XtraReports.UI.XRLabel label4;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRChart chart2;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource3;
        private DevExpress.XtraReports.Parameters.Parameter parRepItemPrefix;
        private DevExpress.XtraReports.Parameters.Parameter parRepInitialDate;
        private DevExpress.XtraReports.Parameters.Parameter parRepFinalDate;
    }
}
