using BookShop.Dal;
using BookShop.Dal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<BookShopDbContext>(                                                         //itt regiszt�ljuk be a BookShopDbContext adatb�zist el�r� service-t a szervizek k�z�
                option => option.UseSqlServer(Configuration.GetConnectionString("BookShopDbContext"))         //itt adjuk meg egy option-�n kereszt�l hogy mi legyen az adatb�zisunk connection stringje
                                                                                                              //ezen connection string-et az appsettings.json-ben deklar�lnunk
            );

            services.AddScoped<BookService>();

            services.AddScoped<CategoryService>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");      //Error.cshtml oldalra ir�ny�t �t
            }

            //a middleware-k beregisztr�l�sa. Fontos a sorrend
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
