using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Pdf;

namespace rxDesktopReportClient
{
    public partial class MainForm : Form
    {
        private readonly string jsonFilePath =
            Properties.Settings.Default.JsonFilePath;

        private BindingList<DeviceConfig> devices;
        private System.Windows.Forms.Timer reportTimer;
        private bool reportRunInProgress = false;
        public MainForm()
        {
            InitializeComponent();
            LoadSavedSettings();

            LoadGridFromJson();
            ConfigureGridEditing();

            ConfigureReportTimer();
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

        private void ConfigureReportTimer()
        {
            if (reportTimer != null)
            {
                reportTimer.Stop();
                reportTimer.Dispose();
            }

            reportTimer = new System.Windows.Forms.Timer();

            int intervalMinutes = Properties.Settings.Default.ReportRunIntervalMinutes;

            if (intervalMinutes <= 0)
                intervalMinutes = 60;

            reportTimer.Interval = intervalMinutes * 60 * 1000;

            reportTimer.Tick += async (s, e) =>
            {
                await RunTimedReportDownloadAsync();
            };

            if (Properties.Settings.Default.EnableTimedReportRuns)
            {
                reportTimer.Start();
            }
        }

        private async Task RunTimedReportDownloadAsync()
        {
            if (reportRunInProgress)
                return;

            reportRunInProgress = true;
            reportTimer.Stop();

            try
            {
                await DownloadReportsAsync();
            }
            catch (Exception ex)
            {
                WriteLog("Timed report download failed: " + ex);
            }
            finally
            {
                reportRunInProgress = false;

                if (Properties.Settings.Default.EnableTimedReportRuns)
                    reportTimer.Start();
            }
        }

        private async Task DownloadReportsAsync()
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

            DateTime reportDate = DateTime.Today.AddDays(-1);

            string currentDate = reportDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string year = reportDate.ToString("yyyy", CultureInfo.InvariantCulture);
            string month = reportDate.ToString("MM", CultureInfo.InvariantCulture);
            string day = reportDate.ToString("dd", CultureInfo.InvariantCulture);

            var groups = devices
                .Where(d => !string.IsNullOrWhiteSpace(d.dispositivo))
                .GroupBy(d => new
                {
                    d.unidadeProd,
                    d.setor
                });

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                foreach (var group in groups)
                {
                    var orderedItems = group
                        .OrderBy(d => GetBaseDeviceName(d.dispositivo), StringComparer.OrdinalIgnoreCase)
                        .ThenBy(d => GetReportOrder(d.dispositivo))
                        .ThenBy(d => d.dispositivo, StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    string outputFolder = Path.Combine(
                        folderPath,
                        MakeSafePathSegment(group.Key.unidadeProd),
                        MakeSafePathSegment(group.Key.setor),
                        year,
                        month,
                        day
                    );

                    Directory.CreateDirectory(outputFolder);

                    string outputFile = Path.Combine(
                        outputFolder,
                        $"JaSaudeSalasTempHR_{MakeSafePathSegment(group.Key.setor)}_{currentDate}_{DateTime.Now:HHmmss}.pdf"
                    );

                    string itemQuery = string.Join(",", orderedItems
                        .Select(d => d.dispositivo.Trim()));

                    string url =
                        baseUrl +
                        "?item=" + Uri.EscapeDataString(itemQuery) +
                        "&dataInicial=" + Uri.EscapeDataString(currentDate) +
                        "&dataFinal=" + Uri.EscapeDataString(currentDate);

                    byte[] pdfBytes = await httpClient.GetByteArrayAsync(url);
                    File.WriteAllBytes(outputFile, pdfBytes);

                    WriteLog("Downloaded report: " + outputFile);
                }
            }
        }

        private static string GetBaseDeviceName(string dispositivo)
        {
            if (string.IsNullOrWhiteSpace(dispositivo))
                return "_";

            dispositivo = dispositivo.Trim();

            string[] suffixes =
            {
        "-Temperatura",
        "-Humidade",
        "-Umidade"
    };

            foreach (string suffix in suffixes)
            {
                if (dispositivo.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    return dispositivo.Substring(0, dispositivo.Length - suffix.Length);
                }
            }

            return dispositivo;
        }

        private static int GetReportOrder(string dispositivo)
        {
            if (dispositivo.EndsWith("-Temperatura", StringComparison.OrdinalIgnoreCase))
                return 1;

            if (dispositivo.EndsWith("-Humidade", StringComparison.OrdinalIgnoreCase) ||
                dispositivo.EndsWith("-Umidade", StringComparison.OrdinalIgnoreCase))
                return 2;

            return 9;
        }

        private static void MergePdfFiles(List<string> inputFiles, string outputFile)
        {
            using (var outputDocument = new PdfSharp.Pdf.PdfDocument())
            {
                foreach (string file in inputFiles)
                {
                    using (var inputDocument = PdfSharp.Pdf.IO.PdfReader.Open(
                        file,
                        PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < inputDocument.PageCount; i++)
                        {
                            outputDocument.AddPage(inputDocument.Pages[i]);
                        }
                    }
                }

                outputDocument.Save(outputFile);
            }
        }

        private void WriteLog(string message)
        {
            try
            {
                string logFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "rxDesktopReportClient",
                    "logs"
                );

                Directory.CreateDirectory(logFolder);

                string logFile = Path.Combine(logFolder, "report-download.log");

                File.AppendAllText(
                    logFile,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message + Environment.NewLine
                );
            }
            catch
            {
                // Never let logging crash the tray app.
            }
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
                await DownloadReportsAsync();
                MessageBox.Show("Reports downloaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading reports:\n" + ex.Message);
            }
            finally
            {
                btnDownloadReport.Enabled = true;
            }
        }

        private async Task DownloadReportAsync()
        {
            if (!IsLegacyDeviceReportGenerationEnabled())
            {
                WriteLog("Legacy per-device report generation is disabled.");
                return;
            }

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

        private static bool IsLegacyDeviceReportGenerationEnabled()
        {
            try
            {
                string configuredValue = System.Configuration.ConfigurationManager
                    .AppSettings["EnableLegacyDeviceReportGeneration"];

                return bool.TryParse(configuredValue, out bool isEnabled) && isEnabled;
            }
            catch (System.Configuration.ConfigurationErrorsException)
            {
                return false;
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
