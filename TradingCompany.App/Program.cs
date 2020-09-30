using System;
using System.Windows.Forms;
using TradingCompany.BusinessLogic.Helpers;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.App
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegistrationForm());
            
        }
    }
}
