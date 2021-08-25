using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FriendlyUrl { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Order { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
