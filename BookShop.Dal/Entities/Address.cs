using System;
using System.Collections.Generic;

//Ati: Ezen entitásokat már a meglévö adatbázisból generáltuk le a következö parancsal (lásd 3. labor):
//Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Address
    {
        public Address()
        {
            UserAddress = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }

        public virtual ICollection<UserAddress> UserAddress { get; set; }
    }
}
