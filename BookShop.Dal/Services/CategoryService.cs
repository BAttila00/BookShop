using BookShop.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Dal.Services {
    public class CategoryService {

        public BookShopDbContext DbContext { get; }
        public CategoryService(BookShopDbContext dbContext) {
            DbContext = dbContext;
        }

        public IEnumerable<CategoryHeader> GetCategoryTreeAsync() {
            var allCategories = DbContext.Category
            .OrderBy(c => c.Order)
            .Select(c => new CategoryHeader {
                Id = c.Id,
                Level = c.Order.Split(".", StringSplitOptions.None).Count(),
                Name = c.DisplayName
            }).ToList();
            return allCategories;
        }

    }
}
