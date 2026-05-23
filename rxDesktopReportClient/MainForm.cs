using System;
using System.IO;
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
    }
}
