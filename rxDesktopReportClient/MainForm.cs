using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rxDesktopReportClient
{
    public partial class MainForm : Form
    {
        private readonly string jsonFilePath =
            Properties.Settings.Default.JsonFilePath;

        private BindingList<DeviceConfig> devices;
        public MainForm()
        {
            InitializeComponent();
            LoadSavedSettings();

            LoadGridFromJson();
            ConfigureGridEditing();
        }

        private void LoadGridFromJson()
        {
            if (!File.Exists(jsonFilePath))
            {
                devices = new BindingList<DeviceConfig>();
            }
            else
            {
                string json = File.ReadAllText(jsonFilePath);

                var list = JsonConvert.DeserializeObject<List<DeviceConfig>>(json)
                           ?? new List<DeviceConfig>();

                devices = new BindingList<DeviceConfig>(list);
            }

            gridControl1.DataSource = devices;
        }

        private void ConfigureGridEditing()
        {
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition =
                DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            gridView1.OptionsBehavior.AllowAddRows =
                DevExpress.Utils.DefaultBoolean.True;

            gridView1.OptionsBehavior.AllowDeleteRows =
                DevExpress.Utils.DefaultBoolean.True;
        }

        private void SaveGridToJson()
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            string json = JsonConvert.SerializeObject(
                devices,
                Formatting.Indented
            );

            File.WriteAllText(jsonFilePath, json);
        }

        private void LoadSavedSettings()
        {
            txtFolderPath.Text = Properties.Settings.Default.SelectedFolderPath;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }

            base.OnFormClosing(e);
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Selecione a pasta raiz para exportação dos relatórios";
                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrWhiteSpace(txtFolderPath.Text) &&
                    Directory.Exists(txtFolderPath.Text))
                {
                    dialog.SelectedPath = txtFolderPath.Text;
                }

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtFolderPath.Text = dialog.SelectedPath;

                    Properties.Settings.Default.SelectedFolderPath = dialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void btnDownloadReport_ClickAsync(object sender, EventArgs e)
        {
            btnDownloadReport.Enabled = false;

            try
            {
                await DownloadReportAsync();
                MessageBox.Show("Relatórios exportados com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no download do relatório:\n" + ex.Message);
            }
            finally
            {
                btnDownloadReport.Enabled = true;
            }
        }

        private async Task DownloadReportAsync()
        {
            string folderPath = Properties.Settings.Default.SelectedFolderPath;
            string baseUrl = Properties.Settings.Default.ReportBaseUrl;
            string jsonFilePath = Properties.Settings.Default.JsonFilePath;

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                throw new InvalidOperationException("Select a valid output folder first.");

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("ReportBaseUrl is not configured.");

            if (string.IsNullOrWhiteSpace(jsonFilePath) || !File.Exists(jsonFilePath))
                throw new InvalidOperationException("JsonFilePath is not configured or file does not exist.");

            string json = File.ReadAllText(jsonFilePath);

            var devices = JsonConvert.DeserializeObject<List<DeviceConfig>>(json)
                          ?? new List<DeviceConfig>();

            if (devices.Count == 0)
                throw new InvalidOperationException("JSON file does not contain any devices.");

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                foreach (var device in devices)
                {
                    if (string.IsNullOrWhiteSpace(device.dispositivo))
                        continue;

                    string item = device.dispositivo.Trim();

                    string url =
                        baseUrl +
                        "?item=" + Uri.EscapeDataString(item) +
                        "&dataInicial=" + Uri.EscapeDataString(currentDate) +
                        "&dataFinal=" + Uri.EscapeDataString(currentDate);

                    string year = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture);
                    string month = DateTime.Now.ToString("MM", CultureInfo.InvariantCulture);
                    string day = DateTime.Now.ToString("dd", CultureInfo.InvariantCulture);

                    string outputFolder = Path.Combine(
                        folderPath,
                        MakeSafePathSegment(device.unidadeProd),
                        MakeSafePathSegment(device.setor),
                        MakeSafePathSegment(device.dispositivo),
                        year,
                        month,
                        day
                    );

                    Directory.CreateDirectory(outputFolder);

                    string outputFile = Path.Combine(
                        outputFolder,
                        $"JaSaudeSalasTempHR_{MakeSafePathSegment(item)}_{currentDate}_{DateTime.Now:HHmmss}.pdf"
                    );

                    byte[] pdfBytes = await httpClient.GetByteArrayAsync(url);

                    File.WriteAllBytes(outputFile, pdfBytes);
                }
            }
        }

        private static string MakeSafePathSegment(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "_";

            value = value.Trim();

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(c, '_');
            }

            return value;
        }

        private static string MakeSafeFileName(string value)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(c, '_');
            }

            return value;
        }

        public class DeviceConfig
        {
            public string dispositivo { get; set; }
            public string unidadeProd { get; set; }
            public string setor { get; set; }
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            try
            {
                SaveGridToJson();
                //MessageBox.Show("Dados salvos com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao salvar dados:\n" + ex.Message);
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !gridView1.IsEditing)
            {
                DeleteSelectedGridRows();
                e.Handled = true;
            }
        }

        private void DeleteSelectedGridRows()
        {
            if (gridView1.SelectedRowsCount <= 0)
                return;

            var result = MessageBox.Show(
                "Delete selected row(s)?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            gridView1.DeleteSelectedRows();

            SaveGridToJson(); // optional: autosave after delete
        }
    }
}
