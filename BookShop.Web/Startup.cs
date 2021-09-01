using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Dal.SeedInterfaces;
using BookShop.Dal.SeedService;
using BookShop.Dal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Web {
    //commit name test
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<BookShopDbContext>(                                                         //itt regisztáljuk be a BookShopDbContext adatbázist elérö service-t a szervizek közé
                option => option.UseSqlServer(Configuration.GetConnectionString("BookShopDbContext"))         //itt adjuk meg egy option-ön keresztül hogy mi legyen az adatbázisunk connection stringje
                                                                                                              //ezen connection string-et az appsettings.json-ben deklarálnunk
            );

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<BookShopDbContext>()
                .AddDefaultTokenProviders();                            //Ati: Jegyzet (5. old.): alapértelmezett token szolgáltatók a különbözö véletlenszerü tokenek generálásáért felelösek....

            services.AddScoped<BookService>();

            services.AddScoped<CategoryService>();

            services.AddScoped<IRoleSeedService, RoleSeedService>();
            services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");      //Error.cshtml oldalra irányít át
            }

            //a middleware-k beregisztrálása. Fontos a sorrend
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
