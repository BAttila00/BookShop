using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

//itt definiáljuk h milyen tábálák legyenek
namespace BookShop.Dal {
    class BookShopDbContext : DbContext {
        public BookShopDbContext() {

        }

        // ezen options-el az adatbázis-kapcsolat konfigurációs beállításait (timeout, connection string) állíthatjuk be.
        public BookShopDbContext(DbContextOptions options) : base(options) { 

        }

        /// <summary>
        /// A könyveket tároló adatbázis tábla
        /// </summary>
        public DbSet<Book> Books { get; set; }
    }
}
