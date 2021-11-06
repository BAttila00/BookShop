using BookShop.Dal;
using BookShop.Dal.Entities;
using BookShop.Dal.SeedInterfaces;
using BookShop.Dal.SeedService;
using BookShop.Dal.Services;
using BookShop.Dal.Users;
using BookShop.Web.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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

            services.AddIdentity<User, IdentityRole<int>>(opt => {
                opt.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<BookShopDbContext>()
                .AddDefaultTokenProviders();                            //Ati: Jegyzet (5. old.): alapértelmezett token szolgáltatók a különbözö véletlenszerü tokenek generálásáért felelösek....

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));  //Ati: A MailSettings.cs fájlba felolvassa a appsettings.Development.json-ben a MailSettings section alatt beállított értékeket
            services.AddTransient<IEmailSender, Services.EmailSender>();                 //Ati: Itt mondjuk meg h az IEmailSender interfész hívásokat (pl a Register.cshtml.cs-ben) a Services.EmailSender szolgálja ki

            services.AddScoped<BookService>();

            services.AddScoped<CategoryService>();

            services.AddScoped<IRoleSeedService, RoleSeedService>();        //Ati: beregisztrálunk egy osztályt service-nek
                                                                            //Azért jó mert ha ezt megtesszük akkor gy tudjuk bárhol elkérni és használni: var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();
                                                                            //Lásd HostDataExtensions.cs
            services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddAuthorization(options => {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(Roles.Administrators));
            });

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
            });

            //Ha olyan oldalra navigálnánk amihez nincs hozzáférésünk navigáljon át a loginra
            services.ConfigureApplicationCookie(options => {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
