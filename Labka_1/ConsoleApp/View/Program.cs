using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
