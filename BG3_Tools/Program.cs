using NLog;
using System;
using System.Windows.Forms;

namespace BG3_Tools
{
    public static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static LoadingForm LoadingF;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(LoadingF = new LoadingForm());

            
        }
    }
}
