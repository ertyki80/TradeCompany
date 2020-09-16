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

            AutorizeLogic autorizeLogic = new AutorizeLogic();
            Role admineRole = new Role(){Name = "Admin"};
            autorizeLogic.Registration("ertuki","1111ae",admineRole,"Ivan","Kintan",Convert.ToDateTime("03/10/01"),"ertyki80@gmail.com" );
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}
