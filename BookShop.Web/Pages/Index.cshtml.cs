using BookShop.Dal;
using BookShop.Dal.Dto;
using BookShop.Dal.Entities;
using BookShop.Dal.Services;
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

        public IEnumerable<BookHeader> Books { get; private set; }
        public void OnGet([FromServices] BookService bookService) {       //Ati: ez a FromServices azért kell elvileg h ne az url-böl próbálja kiszedni a context paramétert
                                                                            //Tehát ez a beregisztrált service-k közül elkéri a BookShopDbContext service-t (startup.cs-ben regisztráltuk be a ConfigureServices metodusban)
            Books = bookService.GetBooks(); // Csak a DEMO mitt érjük el közvetlenül az adatbázist.
        }
    }
}
