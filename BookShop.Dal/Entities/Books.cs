using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Entities {
    public class Books {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int PublishYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}
