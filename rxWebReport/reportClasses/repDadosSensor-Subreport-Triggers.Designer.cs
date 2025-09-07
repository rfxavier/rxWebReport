
namespace rxWebReport.reportClasses
{
    partial class repDadosSensor_Subreport_Triggers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repDadosSensor_Subreport_Triggers));
            DevExpress.DataAccess.ObjectBinding.Parameter parameter1 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter2 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            DevExpress.DataAccess.ObjectBinding.Parameter parameter3 = new DevExpress.DataAccess.ObjectBinding.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.pbOk = new DevExpress.XtraReports.UI.XRPictureBox();
            this.pbAlerta = new DevExpress.XtraReports.UI.XRPictureBox();
            this.label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.calcEvento = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcLocalidade = new DevExpress.XtraReports.UI.CalculatedField();
            this.calcDescription = new DevExpress.XtraReports.UI.CalculatedField();
            this.parRepInitialDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepFinalDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepTriggerTag = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepItemPrefix = new DevExpress.XtraReports.Parameters.Parameter();
            this.parRepHostName = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 3F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 4F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label1});
            this.ReportHeader.HeightF = 24.19433F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 28F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label5,
            this.pbOk,
            this.pbAlerta,
            this.label2,
            this.label3});
            this.Detail.HeightF = 27.00001F;
            this.Detail.Name = "Detail";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Name = "label1";
            this.label1.SizeF = new System.Drawing.SizeF(650F, 24.19433F);
            this.label1.StyleName = "Title";
            this.label1.StylePriority.UseFont = false;
            this.label1.Text = "Lista de Alarmes";
            // 
            // table1
            // 
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(1027.292F, 28F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell3,
            this.tableCell2,
            this.tableCell5});
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StyleName = "DetailCaption1";
            this.tableCell1.StylePriority.UseBorders = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.Text = "Estado";
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell1.Weight = 0.086849645129322015D;
            // 
            // tableCell3
            // 
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StyleName = "DetailCaption1";
            this.tableCell3.Text = "Data";
            this.tableCell3.Weight = 0.23865661151134562D;
            // 
            // tableCell2
            // 
            this.tableCell2.Multiline = true;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "DetailCaption1";
            this.tableCell2.Text = "Tipo";
            this.tableCell2.Weight = 0.17270747608482059D;
            // 
            // tableCell5
            // 
            this.tableCell5.Multiline = true;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.StyleName = "DetailCaption1";
            this.tableCell5.Text = "Descrição";
            this.tableCell5.Weight = 1.1094787798170758D;
            // 
            // label5
            // 
            this.label5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[calcDescription]")});
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label5.LocationFloat = new DevExpress.Utils.PointFloat(318.3511F, 1.999982F);
            this.label5.Multiline = true;
            this.label5.Name = "label5";
            this.label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label5.SizeF = new System.Drawing.SizeF(708.9407F, 25F);
            this.label5.StylePriority.UseFont = false;
            this.label5.StylePriority.UseTextAlignment = false;
            this.label5.Text = "label5";
            this.label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // pbOk
            // 
            this.pbOk.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "[Value] = 0")});
            this.pbOk.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("pbOk.ImageSource"));
            this.pbOk.LocationFloat = new DevExpress.Utils.PointFloat(5.125015F, 0F);
            this.pbOk.Name = "pbOk";
            this.pbOk.SizeF = new System.Drawing.SizeF(32.29166F, 23.95833F);
            this.pbOk.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // pbAlerta
            // 
            this.pbAlerta.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "[Value] = 1")});
            this.pbAlerta.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("pbAlerta.ImageSource"));
            this.pbAlerta.LocationFloat = new DevExpress.Utils.PointFloat(5.125014F, 0.01398722F);
            this.pbAlerta.Name = "pbAlerta";
            this.pbAlerta.SizeF = new System.Drawing.SizeF(32.29166F, 23.95833F);
            this.pbAlerta.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // label2
            // 
            this.label2.BorderColor = System.Drawing.Color.Transparent;
            this.label2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.label2.BorderWidth = 2F;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.LocationFloat = new DevExpress.Utils.PointFloat(207.9937F, 0F);
            this.label2.Name = "label2";
            this.label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.label2.SizeF = new System.Drawing.SizeF(110.3574F, 25F);
            this.label2.StyleName = "DetailData1";
            this.label2.StylePriority.UseBorderColor = false;
            this.label2.StylePriority.UseBorders = false;
            this.label2.StylePriority.UseBorderWidth = false;
            this.label2.StylePriority.UseFont = false;
            this.label2.StylePriority.UseForeColor = false;
            this.label2.StylePriority.UsePadding = false;
            this.label2.StylePriority.UseTextAlignment = false;
            this.label2.Text = "Aviso do sistema";
            this.label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BorderColor = System.Drawing.Color.Transparent;
            this.label3.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.label3.BorderWidth = 2F;
            this.label3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Time]")});
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.LocationFloat = new DevExpress.Utils.PointFloat(56.4523F, 0F);
            this.label3.Name = "label3";
            this.label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.label3.SizeF = new System.Drawing.SizeF(151.5414F, 25F);
            this.label3.StyleName = "DetailData1";
            this.label3.StylePriority.UseBorderColor = false;
            this.label3.StylePriority.UseBorders = false;
            this.label3.StylePriority.UseBorderWidth = false;
            this.label3.StylePriority.UseFont = false;
            this.label3.StylePriority.UseForeColor = false;
            this.label3.StylePriority.UsePadding = false;
            this.label3.StylePriority.UseTextAlignment = false;
            this.label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.label3.TextFormatString = "{0:dd/MM/yy HH:mm:ss}";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetDataTriggers";
            this.objectDataSource1.DataSource = typeof(rxWebReport.dataObjClasses.dsMicroset);
            this.objectDataSource1.Name = "objectDataSource1";
            parameter1.Name = "TriggerTag";
            parameter1.Type = typeof(DevExpress.DataAccess.Expression);
            parameter1.Value = new DevExpress.DataAccess.Expression("?parRepTriggerTag", typeof(string));
            parameter2.Name = "InitialDate";
            parameter2.Type = typeof(DevExpress.DataAccess.Expression);
            parameter2.Value = new DevExpress.DataAccess.Expression("?parRepInitialDate", typeof(string));
            parameter3.Name = "FinalDate";
            parameter3.Type = typeof(DevExpress.DataAccess.Expression);
            parameter3.Value = new DevExpress.DataAccess.Expression("?parRepFinalDate", typeof(string));
            this.objectDataSource1.Parameters.AddRange(new DevExpress.DataAccess.ObjectBinding.Parameter[] {
            parameter1,
            parameter2,
            parameter3});
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // calcEvento
            // 
            this.calcEvento.Expression = "Substring([Description], Len(?parRepItemPrefix))";
            this.calcEvento.Name = "calcEvento";
            // 
            // calcLocalidade
            // 
            this.calcLocalidade.Expression = "Substring([Description], 0, Len(?parRepItemPrefix))\n";
            this.calcLocalidade.Name = "calcLocalidade";
            // 
            // calcDescription
            // 
            this.calcDescription.Expression = "Replace([Description], \'{HOST.NAME}\', ?parRepHostName)";
            this.calcDescription.Name = "calcDescription";
            // 
            // parRepInitialDate
            // 
            this.parRepInitialDate.Name = "parRepInitialDate";
            this.parRepInitialDate.ValueInfo = "2025-05-16";
            this.parRepInitialDate.Visible = false;
            // 
            // parRepFinalDate
            // 
            this.parRepFinalDate.Name = "parRepFinalDate";
            this.parRepFinalDate.ValueInfo = "2025-05-17";
            this.parRepFinalDate.Visible = false;
            // 
            // parRepTriggerTag
            // 
            this.parRepTriggerTag.Name = "parRepTriggerTag";
            this.parRepTriggerTag.ValueInfo = "Sala Limpa";
            this.parRepTriggerTag.Visible = false;
            // 
            // parRepItemPrefix
            // 
            this.parRepItemPrefix.Name = "parRepItemPrefix";
            this.parRepItemPrefix.ValueInfo = "TDP-05BIPE";
            this.parRepItemPrefix.Visible = false;
            // 
            // parRepHostName
            // 
            this.parRepHostName.Name = "parRepHostName";
            this.parRepHostName.ValueInfo = "BOPE";
            this.parRepHostName.Visible = false;
            // 
            // repDadosSensor_Subreport_Triggers
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.Detail});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calcEvento,
            this.calcLocalidade,
            this.calcDescription});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(23, 45, 3, 4);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parRepInitialDate,
            this.parRepFinalDate,
            this.parRepTriggerTag,
            this.parRepItemPrefix,
            this.parRepHostName});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "21.1";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel label5;
        private DevExpress.XtraReports.UI.XRPictureBox pbOk;
        private DevExpress.XtraReports.UI.XRPictureBox pbAlerta;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3_Odd;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.CalculatedField calcEvento;
        private DevExpress.XtraReports.UI.CalculatedField calcLocalidade;
        private DevExpress.XtraReports.UI.CalculatedField calcDescription;
        private DevExpress.XtraReports.Parameters.Parameter parRepInitialDate;
        private DevExpress.XtraReports.Parameters.Parameter parRepFinalDate;
        private DevExpress.XtraReports.Parameters.Parameter parRepTriggerTag;
        private DevExpress.XtraReports.Parameters.Parameter parRepItemPrefix;
        private DevExpress.XtraReports.Parameters.Parameter parRepHostName;
    }
}
