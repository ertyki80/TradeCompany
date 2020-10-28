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
        public static int Id;
        [STAThread]
        public static void Main()
        {
            ConfigureUnity();


            SettingsManager = new AppDataManager();
            bool check = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm lf = Container.Resolve<LoginForm>();
            
            while (check)
            {
                lf.ShowDialog();
                if (lf.DialogResult== DialogResult.Yes)
                {
                    Application.Run(Container.Resolve<RegistrationForm>());
                }
                else if (lf.DialogResult == DialogResult.OK)
                {
                    Id = lf.GetId();
                    Application.Run(Container.Resolve<MainForm>());
                }
                else
                {
                    check = false;
                    Application.Exit();
                }
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
                     .RegisterType<IProductManager, ProductManager>()
                     .RegisterType<ITraderManager, TraderManager>();

        }
    }
}
