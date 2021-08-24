using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Entities {
    public class OrderItem {
        public int Id { get; set; }
        public int? OriginalBookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
