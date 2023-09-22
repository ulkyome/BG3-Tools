using NLog;
using System;
using System.Windows.Forms;

namespace BG3_Tools
{
    internal static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoadingForm());

            
        }
    }
}
