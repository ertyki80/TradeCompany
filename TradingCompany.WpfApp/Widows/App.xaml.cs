using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TradingCompany.BusinessLogic;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Services;
using Unity;

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : System.Windows.Application
    {
        public static UnityContainer Container;
        public static int Id;
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            base.OnStartup(e);
            RegisterUnity();
            RegisterAutoMapper();

            Login lf = Container.Resolve<Login>();
            lf.ShowDialog();

            if (lf.DialogResult == true)
            {
                MainWindow ml = Container.Resolve<MainWindow>();
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = ml;
                ml.Show();
            }
            else
            {
                Current.Shutdown();
            }
        }
        private void RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
               cfg =>
               {
                   cfg.AddMaps(typeof(DataContext).Assembly);
               });
            Container.RegisterInstance(config.CreateMapper());
        }
        private static void RegisterUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUserService, UserService>()
                     .RegisterType<IProductService, ProductService>()
                     .RegisterType<ICategoryService, CategoryService>()
                     .RegisterType<IRoleService, RoleService>()
                     .RegisterType<IStatusService, StatusService>()
                     .RegisterType<ITransactionService, TransactionService>()
                     .RegisterType<ILogsService, LogsService>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IProductManager, ProductManager>()
                     .RegisterType<ITraderManager, TraderManager>();


        }
    }
}
