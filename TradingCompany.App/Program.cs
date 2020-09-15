using System;
using System.Windows.Forms;

namespace TradingCompany.App
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}
