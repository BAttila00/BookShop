using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Web.Hosting;         //az extension method (MigrateDatabase) használata miatt kell ezt be using-olni
using BookShop.Dal;

//Az alkalmazás belépési pontja

namespace BookShop.Web {
    public class Program {
        public static async Task Main(string[] args) {
            (await CreateHostBuilder(args).Build().MigrateDatabaseAsync<BookShopDbContext>()).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();           //lefuttatja a Startup.cs osztályunkat (ez az osztály a fö osztály)
                });
        }
    }
}
