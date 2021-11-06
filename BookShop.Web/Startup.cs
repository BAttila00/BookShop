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

            services.AddDbContext<BookShopDbContext>(                                                         //itt regiszt�ljuk be a BookShopDbContext adatb�zist el�r� service-t a szervizek k�z�
                option => option.UseSqlServer(Configuration.GetConnectionString("BookShopDbContext"))         //itt adjuk meg egy option-�n kereszt�l hogy mi legyen az adatb�zisunk connection stringje
                                                                                                              //ezen connection string-et az appsettings.json-ben deklar�lnunk
            );

            services.AddIdentity<User, IdentityRole<int>>(opt => {
                opt.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<BookShopDbContext>()
                .AddDefaultTokenProviders();                            //Ati: Jegyzet (5. old.): alap�rtelmezett token szolg�ltat�k a k�l�nb�z� v�letlenszer� tokenek gener�l�s��rt felel�sek....

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));  //Ati: A MailSettings.cs f�jlba felolvassa a appsettings.Development.json-ben a MailSettings section alatt be�ll�tott �rt�keket
            services.AddTransient<IEmailSender, Services.EmailSender>();                 //Ati: Itt mondjuk meg h az IEmailSender interf�sz h�v�sokat (pl a Register.cshtml.cs-ben) a Services.EmailSender szolg�lja ki

            services.AddScoped<BookService>();

            services.AddScoped<CategoryService>();

            services.AddScoped<IRoleSeedService, RoleSeedService>();        //Ati: beregisztr�lunk egy oszt�lyt service-nek
                                                                            //Az�rt j� mert ha ezt megtessz�k akkor gy tudjuk b�rhol elk�rni �s haszn�lni: var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();
                                                                            //L�sd HostDataExtensions.cs
            services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddAuthorization(options => {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(Roles.Administrators));
            });

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
            });

            //Ha olyan oldalra navig�ln�nk amihez nincs hozz�f�r�s�nk navig�ljon �t a loginra
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
                app.UseExceptionHandler("/Error");      //Error.cshtml oldalra ir�ny�t �t
            }

            //a middleware-k beregisztr�l�sa. Fontos a sorrend
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
