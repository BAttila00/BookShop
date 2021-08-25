using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Entities {
    public class Order {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
