using BookShop.Dal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Ati: Layout-ban használjuk

namespace BookShop.Web.ViewComponents {
    public class CategoryListViewComponent : ViewComponent {
        public CategoryService CategoryService { get; }
        public CategoryListViewComponent(CategoryService categoryService) {
            CategoryService = categoryService;
        }

        //Layout.cshtml-ben hívódik, ezen a helyen: @await Component.InvokeAsync("CategoryList")
        public async Task<IViewComponentResult> InvokeAsync() {
            return View(await CategoryService.GetCategoryTreeAsync());
        }
        //miután ez a fv lefutott és visszatért egy CategoryHeader listával, automatikusan elkezd futni a BookShop.Web\Pages\Components\CategoryList\Default.cshtml fájl,
        //ahol a model ezen lista lesz.
    }
}
