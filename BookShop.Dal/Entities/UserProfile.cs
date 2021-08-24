using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Comment = new HashSet<Comment>();
            Rating = new HashSet<Rating>();
            UserProfileAddress = new HashSet<UserProfileAddress>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public Guid MembershipId { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<UserProfileAddress> UserProfileAddress { get; set; }
    }
}
