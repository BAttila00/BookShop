using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Dal.Dto {
    public class CategoryHeader {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        [Required]
        public string Order { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
