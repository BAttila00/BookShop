using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Dal.Dto;
using BookShop.Dal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Pages
{
    public class BookModel : PageModel
    {
        private readonly BookService bookService;

        [BindProperty( SupportsGet = true)]
        public int Id { get; set; }

        public BookHeader Book { get; set; }

        public BookModel( BookService bookService)
        {
            this.bookService = bookService;
        }

        public void OnGet()
        {
            Book = bookService.GetBook(Id);
        }
    }
}
