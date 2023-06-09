using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using Serilog;
using System;

namespace OnlineShopWebApp3
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
            string connection = Configuration.GetConnectionString("online_shop");                   //get connection string from the configuration file
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));    // adding context as a service for products
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));    // adding new context for Identity

            services.AddIdentity<User, IdentityRole>() // user type and role
                .AddEntityFrameworkStores<IdentityContext>(); // database type to store

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Authorization/Login";
                options.LogoutPath = "/Account/Authorization/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddTransient<IProductsRepository, ProductsDbRepository>();
            services.AddTransient<IFavouriteRepository, FavouriteDbRepository>();
            services.AddTransient<ICartsRepository, CartsDbRepository>();
            services.AddTransient<IOrdersRepository, OrdersDbRepository>();
            //services.AddSingleton<IRolesRepository, RolesRepositoryInMemory>();
            //services.AddSingleton<IUsersManager, UsersManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication(); // where on the site
            app.UseAuthorization(); // who is authorized

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists=Brand}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
