using System;
using System.Windows.Forms;
using MyWinApp.Views;

namespace MyWinApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen first, but run MainForm as the main app window
            using (var splash = new SplashScreen())
            {
                splash.ShowDialog();  // Show splash as modal dialog; blocks until closed
            }

            Application.Run(new MainForm());  // Main app window
        }
    }
}
