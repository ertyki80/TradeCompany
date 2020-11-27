using AutoMapper;
using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Extensions;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.ConsoleApp
{
    class Program
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(User).Assembly, typeof(Transaction).Assembly, typeof(Status).Assembly, typeof(Role).Assembly, typeof(Product).Assembly, typeof(Logs).Assembly, typeof(Category).Assembly)
            );

            return conf.CreateMapper();
        }

        private static readonly IMapper mapper = SetupMapper();

        public static bool UserMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Users");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Create");
            Console.WriteLine("<2>Read");
            Console.WriteLine("<3>Update");
            Console.WriteLine("<4>Delete");
            Console.WriteLine("<5>Exit");
            Console.Write("\r\nSelect an option: ");
            UserService userService = new UserService(mapper);
            string login;
            string password;
            string role;
            string firstName;
            switch (Console.ReadLine())
            {
               
                case "1":
                    Console.Clear();
                    Console.WriteLine("Login");
                    login = Console.ReadLine();
                    Console.WriteLine("Password");
                    password = Console.ReadLine();
                    Console.WriteLine("Role");
                    role = Console.ReadLine();
                    Console.WriteLine("First Name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Last Name");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Date of Birth");
                    string dateOfBirth = Console.ReadLine();
                    Console.WriteLine("Email");
                    string email = Console.ReadLine();
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("All Users:");
                    IEnumerable<UserDTO> users = userService.GetAllUsers();
                    Extensions userExtensions = new Extensions();
                    foreach (var u in users)
                    {
                        Console.WriteLine(userExtensions.ToString(u));
                    }
                    return true;
                   

                case "3":
                    Console.Clear();
                    Console.WriteLine("Login");
                    login = Console.ReadLine();
                    Console.WriteLine("Password");
                    password = Console.ReadLine();
                    Console.WriteLine("Role");
                    role = Console.ReadLine();
                    Console.WriteLine("First Name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Last Name");
                    lastName = Console.ReadLine();
                    Console.WriteLine("Date of Birth");
                    dateOfBirth = Console.ReadLine();
                    Console.WriteLine("Email");
                    email = Console.ReadLine();
                    Console.WriteLine("Id to change");
                    int id;
                    id = Convert.ToInt32(Console.ReadLine());
                    var Nrole = new RoleDTO() {Name = role, Id = 1};
                    var user = new UserDTO()
                    {
                        DateOfBirth = Convert.ToDateTime(dateOfBirth), Email = email, FirstName = firstName,
                        LastName = lastName, Login = login, Password = password, RoleDTO = Nrole
                    };
                    if (user == null) return true;
                    userService.Update(id, user);

                    return true;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter Id delete element:");
                    id = Convert.ToInt32(Console.ReadLine());
                    userService.Delete(id);
                    return true;

                case "5":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool ProductMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Products");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Create");
            Console.WriteLine("<2>Read");
            Console.WriteLine("<3>Update");
            Console.WriteLine("<4>Delete");
            Console.WriteLine("<5>Exit");
            Console.Write("\r\nSelect an option: ");
            ProductService productService = new ProductService(mapper);
            string category;
            CategoryDTO category_;
            string description;
            int price;
            int countOfStock;
            DateTime TimeofAdd;
            switch (Console.ReadLine())
            {

                case "1":
                    Console.Clear();
                    Console.WriteLine("Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Price");
                    price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Category");
                    category = Console.ReadLine();
                    category_ = new CategoryDTO(){Name = category};
                    Console.WriteLine("Description");
                    description = Console.ReadLine();
                    Console.WriteLine("Count of stock");
                    countOfStock = Convert.ToInt32(Console.ReadLine());
                    TimeofAdd = DateTime.Now;
                    ProductDTO product = new ProductDTO(){Category = category_ ,CountInStock = countOfStock,Description = description,Name=name,Price = price,TimeOfAdd = TimeofAdd};
                   
                    productService.Create(product);

                     return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("All Products:");
                    IEnumerable<ProductDTO> products = productService.GetAllProducts();
                    Extensions productExtension = new Extensions();
                    foreach (var u in products)
                    {
                            Console.WriteLine(productExtension.ToString(u));
                    }
                    Console.WriteLine();
                    return true;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Price");
                    price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Category");
                    category = Console.ReadLine();
                    category_ = new CategoryDTO() { Name = category };
                    Console.WriteLine("Description");
                    description = Console.ReadLine();
                    Console.WriteLine("Count of stock");
                    countOfStock = Convert.ToInt32(Console.ReadLine());
                    TimeofAdd = DateTime.Now;
                    int id;
                    id = Convert.ToInt32(Console.ReadLine());
                    product = new ProductDTO() { Category = category_, CountInStock = countOfStock, Description = description, Name = name, Price = price, TimeOfAdd = TimeofAdd };
                    productService.Update( product);

                    return true;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter Id delete element:");
                    id = Convert.ToInt32(Console.ReadLine());
                    productService.Delete(id);
                    return true;

                case "5":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool CategoryMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Categories");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Read");
            Console.WriteLine("<2>Exit");
            Console.Write("\r\nSelect an option: ");
            CategoryService categoryService = new CategoryService(mapper);
            switch (Console.ReadLine())
            {

                case "1":
                    Console.Clear();
                    Console.WriteLine("All Products:");
                    IEnumerable<CategoryDTO> categoryes = categoryService.GetAllCategory();
                    Extensions productExtension = new Extensions();
                    foreach (var u in categoryes)
                    {
                        Console.WriteLine(productExtension.ToString(u));
                    }
                    return true;


                case "2":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool LogsMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Logs");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Read");
            Console.WriteLine("<2>Exit");
            Console.Write("\r\nSelect an option: ");
            LogsService categoryService = new LogsService(mapper);
            switch (Console.ReadLine())
            {


                case "1":
                    Console.Clear();
                    Console.WriteLine("All Logs :");
                    IEnumerable<LogsDTO> category = categoryService.GetAllLogs();
                    Extensions productExtension = new Extensions();
                    foreach (var u in category)
                    {
                        Console.WriteLine(productExtension.ToString(u));
                    }
                    return true;

               

                case "2":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool RoleMenu()
        {   


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Role");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Read");
            Console.WriteLine("<2>Exit");
            Console.Write("\r\nSelect an option: ");
            RoleService roleService = new RoleService(mapper);
            switch (Console.ReadLine())
            {


                case "1":
                    Console.Clear();
                    Console.WriteLine("All Logs :");
                    IEnumerable<RoleDTO> category = roleService.GetAllRole();
                    Extensions roleExtension = new Extensions();
                    foreach (var u in category)
                    {
                        Console.WriteLine(roleExtension.ToString(u));
                    }
                    return true;



                case "2":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool TransactionsMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Transactions");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Read");
            Console.WriteLine("<2>Exit");
            Console.Write("\r\nSelect an option: ");
            TransactionService roleService = new TransactionService(mapper);
            switch (Console.ReadLine())
            {


                case "1":
                    Console.Clear();
                    Console.WriteLine("All Logs :");
                    IEnumerable<TransactionDTO> category = roleService.GetAllTransactions();
                    Extensions TransactionExtension = new Extensions();
                    foreach (var u in category)
                    {
                        Console.WriteLine(TransactionExtension.ToString(u));
                    }
                    return true;



                case "2":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }
        public static bool StatusMenu()
        {


            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Status");
            Console.WriteLine("Select an operation: ");
            Console.WriteLine("<1>Read");
            Console.WriteLine("<2>Exit");
            Console.Write("\r\nSelect an option: ");
            StatusService roleService = new StatusService(mapper);
            switch (Console.ReadLine())
            {


                case "1":
                    Console.Clear();
                    Console.WriteLine("All Logs :");
                    IEnumerable<StatusDTO> statuses = roleService.GetAllStatus();
                    Extensions statusExtension = new Extensions();
                    foreach (var u in statuses)
                    {
                        Console.WriteLine(statusExtension.ToString(u));
                    }
                    return true;



                case "2":
                    Console.Clear();
                    return false;

            }
            Console.Clear();
            return false;

        }

        private static bool Menu()
        {
            Console.WriteLine("<<Trading Company>>");
            Console.WriteLine("CRUD operation");
            Console.WriteLine("Select an Table: ");
            Console.WriteLine("<1>Users");
            Console.WriteLine("<2>Products");
            Console.WriteLine("<3>Categories");
            Console.WriteLine("<4>Logs");
            Console.WriteLine("<5>Roles");
            Console.WriteLine("<6>Transactions");
            Console.WriteLine("<7>Status");
            Console.WriteLine("<8>Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    var showMenu = true;
                    while (showMenu)
                    {
                        showMenu = UserMenu();
                    }
                    return true;

                case "2":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = ProductMenu();
                    }
                    return true;
                case "3":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = CategoryMenu();
                    }
                    return true;
                case "4":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = LogsMenu();
                    }
                    return true;

                case "5":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = RoleMenu();
                    }
                    return true;
                case "6":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = TransactionsMenu();
                    }
                    return true;

                case "7":
                    Console.Clear();
                    showMenu = true;
                    while (showMenu)
                    {
                        showMenu = StatusMenu();
                    }
                    return true;

                case "8":
                    return false;
                default:
                    return true;
            }
        }





        static void Main(string[] args)
        {
            var showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }

        }
    }
}
