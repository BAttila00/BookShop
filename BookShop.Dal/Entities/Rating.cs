using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int ProductId { get; set; }
        public int UserProfileId { get; set; }

        public virtual Book Product { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
