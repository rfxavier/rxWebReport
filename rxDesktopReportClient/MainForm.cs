using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rxDesktopReportClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSavedSettings();
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
                dialog.Description = "Select the folder used by rxDesktopReportClient";
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
                MessageBox.Show("Report downloaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading report:\n" + ex.Message);
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

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                throw new InvalidOperationException("Select a valid output folder first.");

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("ReportBaseUrl is not configured.");

            string item = "REG-01APQ-Umidade";
            string dataInicial = "2026-05-10";
            string dataFinal = "2026-05-10";

            string url =
                baseUrl +
                "?item=" + Uri.EscapeDataString(item) +
                "&dataInicial=" + Uri.EscapeDataString(dataInicial) +
                "&dataFinal=" + Uri.EscapeDataString(dataFinal);

            string outputFile = Path.Combine(
                folderPath,
                $"JaSaudeSalasTempHR_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            );

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                byte[] pdfBytes = await httpClient.GetByteArrayAsync(url);
                File.WriteAllBytes(outputFile, pdfBytes);
            }
        }
    }
}
