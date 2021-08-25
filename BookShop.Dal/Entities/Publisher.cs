using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Publisher
    {
        public Publisher()
        {
            Product = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FriendlyUrl { get; set; }

        public virtual ICollection<Book> Product { get; set; }
    }
}
