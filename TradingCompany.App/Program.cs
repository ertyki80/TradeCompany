using AutoMapper;
using System;
using System.Windows.Forms;
using TradingCompany.App.AppSetting;
using TradingCompany.BusinessLogic;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Services;
using Unity;

namespace TradingCompany.App
{
    internal static class Program
    {
        public static AppDataManager SettingsManager;
        public static UnityContainer Container;

        [STAThread]
        public static void Main()
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsManager = new AppDataManager();
            LoginForm lf = Container.Resolve<LoginForm>();

            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<MainForm>());
            }
            else
            {
                Application.Exit();
            }


        }
        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(ProductService).Assembly);
                });

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IUserService, UserService>()
                     .RegisterType<IProductService, ProductService>()
                     .RegisterType<ICategoryService, CategoryService>()
                     .RegisterType<IRoleService, RoleService>()
                     .RegisterType<IStatusService, StatusService>()
                     .RegisterType<ITransactionService, TransactionService>()
                     .RegisterType<ILogsService, LogsService>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IProductManager, ProductManager>();
        }
    }
}
