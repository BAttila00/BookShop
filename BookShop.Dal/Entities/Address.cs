using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Address
    {
        public Address()
        {
            UserProfileAddress = new HashSet<UserProfileAddress>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }

        public virtual ICollection<UserProfileAddress> UserProfileAddress { get; set; }
    }
}
