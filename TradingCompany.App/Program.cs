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
            Application.Run(new MainForm());
            //Application.Run(new Catalog(new User()
            //{
            //    DateOfBirth = DateTime.Now,
            //    Email = "aaaa",
            //    FirstName = " aaaaa",
            //    LastName = "vvvvv",
            //    Login = "edaa",
            //    Password = "afagvasd",
            //    Role = new Role(){Name = "afadsv"},
            //    TimeOfCreating = DateTime.Now
            //}));

        }
    }
}
