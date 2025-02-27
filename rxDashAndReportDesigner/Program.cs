using rxWebReport.dataObjClasses;
using System;
using System.Windows.Forms;

namespace rxDashAndReportDesigner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dummy = new dsCofre();
            Application.Run(new FormReportDesigner());
            //Application.Run(new FormDashboardDesigner());
        }
    }
}
