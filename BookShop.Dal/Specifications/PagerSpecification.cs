using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Specifications {
    public class PagerSpecification {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
