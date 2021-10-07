using BookShop.Dal.Dto;
using BookShop.Dal.Entities;
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
                Level = c.Order.Split(".", StringSplitOptions.None).Count(),        //Ati: Ezt nem nagyon értem h mi ez a level, de sztem mind1 is.  //Hát az h melyik szinten van a kategória
                                                                                    //pl bogárnak a rovar a szülőkategóriája így az lesz magasabb szinten.
                Name = c.DisplayName,
                Order = c.Order,
                ParentCategoryId = c.ParentCategoryId
            }).ToListAsync();
            return allCategories;
        }

        public async Task AddOrUpdateCategory(CategoryHeader categoryHeader) {
            if (categoryHeader.Id == 0) {
                var category = new Category {
                    DisplayName = categoryHeader.Name,
                    Order = categoryHeader.Order,
                    ParentCategoryId = categoryHeader.ParentCategoryId
                };
                DbContext.Category.Add(category);
                await DbContext.SaveChangesAsync();
            }
            else {
                var category = DbContext.Category.Single(c => c.Id == categoryHeader.Id);
                category.DisplayName = categoryHeader.Name;
                category.Order = categoryHeader.Order;
                category.ParentCategoryId = categoryHeader.ParentCategoryId;
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int categoryId) {
            // var category = DbContext.Categories.Single(c => c.ID == categoryId);
            // DbContext.Categories.Remove(category);
            DbContext.Category.Remove(new Category { Id = categoryId });
            await DbContext.SaveChangesAsync();
        }
    }
}
