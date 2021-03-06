using BookShop.Dal.SeedInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Pl adatbázis legenerálásához használjuk

namespace BookShop.Web.Hosting {
    public static class HostDataExtensions {

        //Ati:
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
        //egy extension method, segítségével új funkcióval láthatunk el típusokat
        //jelen esetben egy IHost típust láttunk el új funkcióval (this IHost host rész miatt).
        //Ezek után, ha be usingoljuk a BookShop.Web.Hosting névteret vhova ott tudni fogjuk használni a MigrateDatabase metódust egy IHost példányon.
        //pl: host.MigrateDatabase()

        //Ati: Lefuttat egy létrehozott adatbázis migrációt, ha az még nem futott le. Akkor fut le amikor elindítjuk a Web projektet.
        public static async Task<IHost> MigrateDatabaseAsync<TContext>(this IHost host) where TContext : DbContext {
            using (var scope = host.Services.CreateScope()) {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TContext>();           //ez itt még hibát dobott (mostmár nem fog), mert nincs beregisztrálva a GetRequiredService<BookShopDbContext> a service-k közé
                context.Database.Migrate();                                             //Lefuttat egy létrehozott adatbázis migrációt (Ezek a Dal projekt Migrations mappájában vannak), ha az még nem futott le.
                
                var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();        //A startup-ban regisztráltuk be ezt az interface-t egy service-ként, ezzel a sorral: services.AddScoped<IRoleSeedService, RoleSeedService>();
                await roleSeeder.SeedRoleAsync();
                var userSeeder = serviceProvider.GetRequiredService<IUserSeedService>();
                await userSeeder.SeedUserAsync();
            }
            return host;
        }
    }
}
