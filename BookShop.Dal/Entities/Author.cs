using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Author
    {
        public Author()
        {
            ProductAuthor = new HashSet<ProductAuthor>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FriendlyUrl { get; set; }
        public string PhotoUrl { get; set; }
        public string About { get; set; }

        public virtual ICollection<ProductAuthor> ProductAuthor { get; set; }
    }
}
