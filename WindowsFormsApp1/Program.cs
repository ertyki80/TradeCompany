using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (DataContext db = new DataContext())
            {
                Role role = new Role { Name = "Admin" };
               // User user1 = new User { FirstName = "Ivan", LastName = "Kihtan", Login = "ertyki", DateOfBirth = Convert.ToDateTime("03/10/01"), Email = "ertyki80@gmail.com", Password = "eq114", Role = role };
                //User user2 = new User { FirstName = "Sasha", LastName = "Starodub", Login = "srodub", DateOfBirth = Convert.ToDateTime("04/11/01"), Email = "starodub@gmail.com", Password = "11111", Role = role };
                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.SaveChanges();
                //userService.Create(user1);
                //userService.Create(user2);

                Console.WriteLine("Save");

                //var userN = db.Users;
                //Console.WriteLine("List :");
                //foreach (User u in userN)
                //{
                //    Console.WriteLine("{0}.{1} {2} ", u.Id, u.LastName, u.FirstName);
                //}
            }
            using (DataContext db = new DataContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Login, u.Password);
                }
            }
            Console.Read();
        
        }
    }
}
