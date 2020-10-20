using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.EnterpriseServices;
using System.Runtime.InteropServices;


namespace TradingCompany.DataAccess.Test
{
    /// <summary>
    /// Summary description for UserTest
    /// </summary>
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    [TestClass]
    public class UserTest: ServicedComponent
    {
        public readonly DataContext _context = new DataContext();


        public UserTest()
        {
        }

        public UserTest(DataContext context)
        {
            context = _context;
        }

        [TestMethod]
        public void TestMethod1()
        {

            //Arrange
            var users =  new UserExtended()
                {
                    DateOfBirth = Convert.ToDateTime("11/03/2001"), Email = "iiii@gmail.com", FirstName = "Oleh",
                    LastName = "Kolima",
                    Login = "ueuued", Password = "1231", TimeOfCreating = DateTime.Now
            };
            //Act
            DataContext dataContext = new DataContext();
            dataContext.Users.Add(users);
            var user = dataContext.Users.Where(c => c.Login == "ueuued").FirstOrDefault();
            //Assert

            Assert.IsTrue(user.Id != 0, "Returned ID should be more than zero");

        }

        [TestMethod]
        public void GetAllTest()
        {
            var user = new UserExtended()
            {
                DateOfBirth = Convert.ToDateTime("11/03/2001"),
                Email = "iiii@gmail.com",
                FirstName = "Oleh",
                LastName = "Kolima",
                Login = "ueuued",
                Password = "1231",
                TimeOfCreating = DateTime.Now
            };
            DataContext dataContext=new DataContext();
            var result = dataContext.Users.Add(user);
            var users = dataContext.Users;
            Assert.AreEqual(1, users.Count(x => x.FirstName == "Oleh"));
        }



        [TearDown]
        public void Teardown()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }

        }
    }
}