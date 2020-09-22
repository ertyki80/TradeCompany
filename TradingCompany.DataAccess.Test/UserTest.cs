using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using System.Runtime.InteropServices;
using System.Transactions;
using TradingCompany.BusinessLogic.Services;

namespace TradingCompany.DataAccess.Test
{
    /// <summary>
    /// Summary description for UserTest
    /// </summary>
    
    [TestClass]
    public class UserTest
    {
        private readonly DataContext _context;


        public UserTest()
        { }
        public UserTest(DataContext context)
        {
            context = _context;
        }
        
        [TestMethod]
        public void TestMethod1()
        {

            //Arrange
            var users = new[]
            {
                new User()
                {
                    DateOfBirth = Convert.ToDateTime("01/02/2001"), Email = "ertyki80@gmail.com", FirstName = "Ivan",
                    LastName = "Kihtan",
                    Login = "ertyki", Password = "1111", TimeOfCreating = DateTime.Now
                },
                new User()
                {
                    DateOfBirth = Convert.ToDateTime("11/03/2001"), Email = "iiii@gmail.com", FirstName = "Oleh",
                    LastName = "Kolima",
                    Login = "ueuued", Password = "1231", TimeOfCreating = DateTime.Now
                }
            };
            //Act

            DataContext dataContext = new DataContext();
            var usersAll = dataContext.Users.Count();
            
            dataContext.Users.AddRange(users);
            dataContext.SaveChanges();
            var countUsers = dataContext.Users.Count();

            //Assert

            Assert.AreEqual(usersAll+2, countUsers);

        }

        [TearDown]
        public void TearDown()
        {


        }
    }
}
