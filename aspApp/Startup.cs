using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Services;

namespace aspApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<ITraderManager, TraderManager>();
            services.AddTransient<ICategoryService, CategoryService>()
                     .AddTransient<IUserService, UserService>()
                     .AddTransient<IProductService, ProductService>()
                     .AddTransient<ICategoryService, CategoryService>()
                     .AddTransient<IRoleService, RoleService>()
                     .AddTransient<IStatusService, StatusService>()
                     .AddTransient<ITransactionService, TransactionService>()
                     .AddTransient<ILogsService, LogsService>()
                     .AddTransient<IAuthManager, AuthManager>()
                     .AddTransient<IProductManager, ProductManager>()
                     .AddTransient<ITraderManager, TraderManager>();

            MapperConfiguration config = new MapperConfiguration(
               cfg =>
               {
                   cfg.AddMaps(typeof(ProductService).Assembly);
               });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
