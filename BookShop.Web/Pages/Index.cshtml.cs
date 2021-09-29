using BookShop.Dal;
using BookShop.Dal.Dto;
using BookShop.Dal.Entities;
using BookShop.Dal.Services;
using BookShop.Dal.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]                              //Ati: Ha talál az url-ben "PageNumber" illetve "PageSize" paramétereket azokat automatikusan kiveszi az url-böl és betölti ebbe a mezöbe
        public PagerSpecification Specification { get; set; }

        [BindProperty(SupportsGet = true)]
        public BooksSpecification BooksSpecification { get; set; }

        public PagedResult<BookHeader> Books { get; private set; }
        public void OnGet([FromServices] BookService bookService) {       //Ati: ez a FromServices azért kell elvileg h ne az url-böl próbálja kiszedni a context paramétert
                                                                                           //Tehát ez a beregisztrált service-k közül elkéri a BookShopDbContext service-t (startup.cs-ben regisztráltuk be a ConfigureServices metodusban)
                                                                                           //Ati: Az url-ből ki fogja szedni a pageNumber paramétert (pl ha ez az url http://localhost:6211/?pageNumber=3)
            Books = bookService.GetBooks(Specification, BooksSpecification);
        }
    }
}
