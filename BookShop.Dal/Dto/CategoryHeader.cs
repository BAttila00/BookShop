using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Dto {
    public class CategoryHeader {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
