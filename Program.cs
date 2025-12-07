using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Phase 2: Start directly with MainForm (no login)
            Application.Run(new MainForm());
        }
    }
}