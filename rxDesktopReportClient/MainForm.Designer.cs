
namespace rxDesktopReportClient
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode1 = new DevExpress.DataAccess.Json.JsonSchemaNode("root", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode2 = new DevExpress.DataAccess.Json.JsonSchemaNode("dispositivo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode3 = new DevExpress.DataAccess.Json.JsonSchemaNode("unidadeProd", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode4 = new DevExpress.DataAccess.Json.JsonSchemaNode("setor", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnDownloadReport = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.jsonDataSource1 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldispositivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colunidadeProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsetor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(37, 264);
            this.btnChooseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(127, 49);
            this.btnChooseFolder.TabIndex = 0;
            this.btnChooseFolder.Text = "Escolher Pasta Raiz";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(37, 326);
            this.txtFolderPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(482, 20);
            this.txtFolderPath.TabIndex = 1;
            // 
            // btnDownloadReport
            // 
            this.btnDownloadReport.Location = new System.Drawing.Point(631, 310);
            this.btnDownloadReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadReport.Name = "btnDownloadReport";
            this.btnDownloadReport.Size = new System.Drawing.Size(75, 36);
            this.btnDownloadReport.TabIndex = 2;
            this.btnDownloadReport.Text = "Exportar Relatórios";
            this.btnDownloadReport.UseVisualStyleBackColor = true;
            this.btnDownloadReport.Click += new System.EventHandler(this.btnDownloadReport_ClickAsync);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.jsonDataSource1;
            this.gridControl1.Location = new System.Drawing.Point(37, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(665, 200);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
            // 
            // jsonDataSource1
            // 
            this.jsonDataSource1.ConnectionName = "JsonConnection";
            this.jsonDataSource1.Name = "jsonDataSource1";
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode2);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode3);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode4);
            this.jsonDataSource1.Schema = jsonSchemaNode1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldispositivo,
            this.colunidadeProd,
            this.colsetor});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // coldispositivo
            // 
            this.coldispositivo.FieldName = "dispositivo";
            this.coldispositivo.Name = "coldispositivo";
            this.coldispositivo.Visible = true;
            this.coldispositivo.VisibleIndex = 0;
            // 
            // colunidadeProd
            // 
            this.colunidadeProd.FieldName = "unidadeProd";
            this.colunidadeProd.Name = "colunidadeProd";
            this.colunidadeProd.Visible = true;
            this.colunidadeProd.VisibleIndex = 1;
            // 
            // colsetor
            // 
            this.colsetor.FieldName = "setor";
            this.colsetor.Name = "colsetor";
            this.colsetor.Visible = true;
            this.colsetor.VisibleIndex = 2;
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.Location = new System.Drawing.Point(539, 236);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(163, 23);
            this.btnSaveJson.TabIndex = 4;
            this.btnSaveJson.Text = "Salvar Tabela de Dispositivos";
            this.btnSaveJson.UseVisualStyleBackColor = true;
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tabela de Dispositivos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnDownloadReport);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnChooseFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Configuração Relatórios";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnDownloadReport;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource1;
        private DevExpress.XtraGrid.Columns.GridColumn coldispositivo;
        private DevExpress.XtraGrid.Columns.GridColumn colunidadeProd;
        private DevExpress.XtraGrid.Columns.GridColumn colsetor;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Label label1;
    }
}

