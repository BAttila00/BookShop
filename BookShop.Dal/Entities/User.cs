using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Rating = new HashSet<Rating>();
            UserAddress = new HashSet<UserAddress>();
            Orders = new HashSet<Order>();
        }

        public string DisplayName { get; set; }
        public Guid MembershipId { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<UserAddress> UserAddress { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
