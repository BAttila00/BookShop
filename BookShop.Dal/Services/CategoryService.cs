using BookShop.Dal.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dal.Services {
    public class CategoryService {

        public BookShopDbContext DbContext { get; }
        public CategoryService(BookShopDbContext dbContext) {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryHeader>> GetCategoryTreeAsync() {
            var allCategories = await DbContext.Category
            .OrderBy(c => c.Order)
            .Select(c => new CategoryHeader {
                Id = c.Id,
                Level = c.Order.Split(".", StringSplitOptions.None).Count(),        //Ati: Ezt nem nagyon értem h mi ez a level, de sztem mind1 is.
                Name = c.DisplayName
            }).ToListAsync();
            return allCategories;
        }

    }
}
