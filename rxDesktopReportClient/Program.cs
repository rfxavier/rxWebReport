using rxDesktopReportClient;
using System;
using System.Windows.Forms;

namespace rxWebReportTray
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            var tray = new NotifyIcon
            {
                Icon = rxDesktopReportClient.Properties.Resources.trayIcon,
                Visible = true,
                Text = "Relatórios Autoextração"
            };

            tray.DoubleClick += (s, e) =>
            {
                if (mainForm.Visible)
                {
                    mainForm.Hide();
                }
                else
                {
                    mainForm.Show();
                    mainForm.WindowState = FormWindowState.Normal;
                    mainForm.Activate();
                }
            };

            var menu = new ContextMenuStrip();

            menu.Items.Add("Open", null, (s, e) =>
            {
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
                mainForm.Activate();
            });

            menu.Items.Add("Exit", null, (s, e) =>
            {
                tray.Visible = false;
                Application.Exit();
            });

            tray.ContextMenuStrip = menu;

            mainForm.Hide();

            Application.Run();
        }
    }
}