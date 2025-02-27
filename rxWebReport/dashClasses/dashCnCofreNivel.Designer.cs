
namespace rxWebReport.dashClasses
{
    partial class dashCnCofreNivel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn1 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn2 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.GridMeasureColumn gridMeasureColumn1 = new DevExpress.DashboardCommon.GridMeasureColumn();
            DevExpress.DashboardCommon.Dimension dimension3 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.GridDimensionColumn gridDimensionColumn3 = new DevExpress.DashboardCommon.GridDimensionColumn();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule1 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionBar formatConditionBar1 = new DevExpress.DashboardCommon.FormatConditionBar();
            DevExpress.DashboardCommon.GridItemFormatRule gridItemFormatRule2 = new DevExpress.DashboardCommon.GridItemFormatRule();
            DevExpress.DashboardCommon.FormatConditionBar formatConditionBar2 = new DevExpress.DashboardCommon.FormatConditionBar();
            DevExpress.DashboardCommon.Dimension dimension4 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension5 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension6 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension7 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.CalculatedField calculatedField1 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DashboardCommon.CalculatedField calculatedField2 = new DevExpress.DashboardCommon.CalculatedField();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.gridDashboardItem1 = new DevExpress.DashboardCommon.GridDashboardItem();
            this.treeViewDashboardItem1 = new DevExpress.DashboardCommon.TreeViewDashboardItem();
            this.dashboardObjectDataSource1 = new DevExpress.DashboardCommon.DashboardObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // gridDashboardItem1
            // 
            dimension1.DataMember = "id_cofre";
            dimension1.Name = "Cofre Id";
            gridDimensionColumn1.Weight = 11.752852447526927D;
            gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn1.AddDataItem("Dimension", dimension1);
            dimension2.DataMember = "cofre_nome";
            dimension2.Name = "Cofre Nome";
            gridDimensionColumn2.Weight = 39.3938202407847D;
            gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn2.AddDataItem("Dimension", dimension2);
            measure1.DataMember = "data_sensor_perc";
            measure1.Name = "Nível";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Percent;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Precision = 0;
            gridMeasureColumn1.Weight = 84.098188624526D;
            gridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridMeasureColumn1.AddDataItem("Measure", measure1);
            dimension3.DataMember = "data_tmst_end_datetime";
            dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHourMinuteSecond;
            dimension3.Name = "Data Informação";
            gridDimensionColumn3.Weight = 22.33041965030116D;
            gridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight;
            gridDimensionColumn3.AddDataItem("Dimension", dimension3);
            this.gridDashboardItem1.Columns.AddRange(new DevExpress.DashboardCommon.GridColumnBase[] {
            gridDimensionColumn1,
            gridDimensionColumn2,
            gridMeasureColumn1,
            gridDimensionColumn3});
            this.gridDashboardItem1.ComponentName = "gridDashboardItem1";
            this.gridDashboardItem1.DataItemRepository.Clear();
            this.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.gridDashboardItem1.DataItemRepository.Add(dimension3, "DataItem1");
            this.gridDashboardItem1.DataItemRepository.Add(measure1, "DataItem2");
            this.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem3");
            this.gridDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            formatConditionBar1.BarOptions.AllowNegativeAxis = false;
            formatConditionBar1.BarOptions.ShowBarOnly = true;
            formatConditionBar1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionBar1.MaximumType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent;
            formatConditionBar1.NegativeStyleSettings.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.PaleRed;
            formatConditionBar1.StyleSettings.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Red;
            gridItemFormatRule1.Condition = formatConditionBar1;
            gridItemFormatRule1.Enabled = false;
            gridItemFormatRule1.Name = "FormatRule 1";
            formatConditionBar2.BarOptions.DrawAxis = true;
            formatConditionBar2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            formatConditionBar2.MaximumType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent;
            formatConditionBar2.NegativeStyleSettings.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.PaleRed;
            formatConditionBar2.StyleSettings.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Blue;
            gridItemFormatRule2.Condition = formatConditionBar2;
            gridItemFormatRule2.DataItem = measure1;
            gridItemFormatRule2.DataItemApplyTo = measure1;
            gridItemFormatRule2.Name = "FormatRule 2";
            this.gridDashboardItem1.FormatRules.AddRange(new DevExpress.DashboardCommon.GridItemFormatRule[] {
            gridItemFormatRule1,
            gridItemFormatRule2});
            this.gridDashboardItem1.GridOptions.ColumnWidthMode = DevExpress.DashboardCommon.GridColumnWidthMode.Manual;
            this.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.gridDashboardItem1.Name = "Grid 1";
            this.gridDashboardItem1.ShowCaption = false;
            this.gridDashboardItem1.VisibleDataFilterString = "[DataItem0] Not Like \'------%\'";
            // 
            // treeViewDashboardItem1
            // 
            this.treeViewDashboardItem1.ComponentName = "treeViewDashboardItem1";
            dimension4.DataMember = "nome_rede";
            dimension5.DataMember = "nome_cliente";
            dimension6.DataMember = "nome_loja";
            dimension7.DataMember = "id_cofre";
            this.treeViewDashboardItem1.DataItemRepository.Clear();
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension4, "DataItem0");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension5, "DataItem1");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension6, "DataItem2");
            this.treeViewDashboardItem1.DataItemRepository.Add(dimension7, "DataItem3");
            this.treeViewDashboardItem1.DataSource = this.dashboardObjectDataSource1;
            this.treeViewDashboardItem1.FilterDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension4,
            dimension5,
            dimension6});
            this.treeViewDashboardItem1.HiddenDimensions.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension7});
            this.treeViewDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.treeViewDashboardItem1.Name = "Rede - Cliente - Loja";
            this.treeViewDashboardItem1.ShowCaption = true;
            this.treeViewDashboardItem1.VisibleDataFilterString = "[DataItem3] Not Like \'------%\'";
            // 
            // dashboardObjectDataSource1
            // 
            calculatedField1.Expression = "[data_sensor] / 100";
            calculatedField1.Name = "data_sensor_perc";
            calculatedField2.Expression = "1";
            calculatedField2.Name = "one";
            this.dashboardObjectDataSource1.CalculatedFields.AddRange(new DevExpress.DashboardCommon.CalculatedField[] {
            calculatedField1,
            calculatedField2});
            this.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1";
            this.dashboardObjectDataSource1.DataMember = "GetCofreNivel";
            this.dashboardObjectDataSource1.DataSource = typeof(rxWebReport.dataObjClasses.dsCofre);
            this.dashboardObjectDataSource1.Name = "Object Data Source 1";
            // 
            // dashCnCofreNivel
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardObjectDataSource1});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.gridDashboardItem1,
            this.treeViewDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.treeViewDashboardItem1;
            dashboardLayoutItem1.Weight = 19.395017793594306D;
            dashboardLayoutItem2.DashboardItem = this.gridDashboardItem1;
            dashboardLayoutItem2.Weight = 80.6049822064057D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutItem2});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Cofre Níveis";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.GridDashboardItem gridDashboardItem1;
        private DevExpress.DashboardCommon.DashboardObjectDataSource dashboardObjectDataSource1;
        private DevExpress.DashboardCommon.TreeViewDashboardItem treeViewDashboardItem1;
    }
}
