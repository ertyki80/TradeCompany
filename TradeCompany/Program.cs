using BusinessLogic;
using DataAccess;
using System;
namespace PresentationLayer
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (DataContext db = new DataContext())
            {
                
                //var userN = db.Users;
                //Console.WriteLine("List :");
                //foreach (User u in userN)
                //{
                //    Console.WriteLine("{0}.{1} {2} ", u.Id, u.LastName, u.FirstName);
                //}
            }
            Console.Read();
        }
    }
}
