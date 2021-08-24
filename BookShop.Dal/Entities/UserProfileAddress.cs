using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class UserProfileAddress
    {
        public int UserProfileId { get; set; }
        public int AddressId { get; set; }
        public int Type { get; set; }
        public bool IsDefault { get; set; }

        public virtual Address Address { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
