using System;
using System.Collections.Generic;
using System.Text;

//Ati: ezt még mi hoztuk létre
//A többi entitást már a meglévö adatbázisból generáltuk le a
//Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force parancsal (lásd 3. labor)
namespace BookShop.Dal.Entities {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int PublishYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}
