﻿using BookShop.Dal;
using BookShop.Dal.Entities;
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

        public IEnumerable<Book> Books { get; private set; }
        public void OnGet([FromServices] BookShopDbContext context) {       //Ati: ez a FromServices azért kell elvileg h ne az url-böl próbálja kiszedni a context paramétert
                                                                            //Tehát ez a beregisztrált service-k közül elkéri a BookShopDbContext service-t (startup.cs-ben regisztráltuk be a ConfigureServices metodusban)
            Books = context.Book.ToList(); // Csak a DEMO mitt érjük el közvetlenül az adatbázist.
        }
    }
}
