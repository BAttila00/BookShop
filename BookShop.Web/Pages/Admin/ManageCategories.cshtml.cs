using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Dal.Dto;
using BookShop.Dal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Web.Pages.Admin
{
    public class ManageCategoriesModel : PageModel {
        private readonly CategoryService categoryService;
        public IEnumerable<SelectListItem> AllCategories;                   //Ati: ez érdekes lehet ez a SelectListItem cucc
        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }
        [BindProperty()]
        public CategoryHeader SelectedCategory { get; set; }
        public ManageCategoriesModel(CategoryService categoryService) {
            this.categoryService = categoryService;
        }
        public async Task OnGetAsync() {
            var allCategories = await categoryService.GetCategoryTreeAsync();
            AllCategories = allCategories.Select(c => new SelectListItem {
                Text = c.Name.PadLeft(c.Name.Length + (c.Order.Split('.').Length - 1) * 2, '\xA0'),
                Value = c.Id.ToString()
            });
            if (CategoryId != 0)
                SelectedCategory = allCategories.Single(c => c.Id == CategoryId);
            else
                SelectedCategory = new CategoryHeader();
        }

        //Ati: itt fontos a pontos elnevezés. Ennek kell megfeleljen: <button asp-page-handler="AddOrUpdate"
        //A fölötte lévö cshtml fájlban van
        public async Task<IActionResult> OnPostAddOrUpdateAsync() {
            if (ModelState.IsValid) {
                await categoryService.AddOrUpdateCategory(SelectedCategory);
                return new RedirectToPageResult("/Admin/ManageCategories");
                //Ati: ugyan az mint RedirectToPage("/Admin/ManageCategories");
            }
            // TODO: Hiba esetén a Model-t újra betölteni.
            return Page();
        }

        //Ati: itt fontos a pontos elnevezés. Ennek kell megfeleljen: <button asp-page-handler="Delete"
        //A fölötte lévö cshtml fájlban van
        public async Task<IActionResult> OnPostDeleteAsync() {
            await categoryService.DeleteCategory(SelectedCategory.Id);
            return new RedirectToPageResult("/Admin/ManageCategories");
            //Ati: ugyan az mint return RedirectToPage("/Admin/ManageCategories");
        }
    }
}
