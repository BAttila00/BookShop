using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Web.ViewComponents {

    //Ati: fontos a pontos elnevezés. A Pages\Components\ mappában kell létrehozni egy ilyen nevü mappát (ViewComponent nélkül, tehát a mappa neve Pager kell legyen)
    //és abban elhelyezni egy Default.cshtml razeor Page-et.
    public class PagerViewComponent : ViewComponent {
        public class PagerSpecification {       //ezeket az attribútumokat azért kell összefognunk egy objektumban, mert a View() (lent) csak 1 paramétert vár.
            public int AllResultsCount { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages { get; set; }
            public int PagesToShow { get; set; }        //Ati: Arra szolgál h ha pl a 10. oldalon vagyunk akkor elötte illettve utána is pl csak 3 oldal jelenjen meg (a lapozó sávban)
        }
        public IViewComponentResult Invoke(int pageSize, int pageNumber,
        int allResultsCount, int pagesToShow) {
            return View(new PagerSpecification {
                PageSize = pageSize,
                PageNumber = pageNumber,
                AllResultsCount = allResultsCount,
                TotalPages = (int)Math.Ceiling((double)allResultsCount / (double)pageSize),
                PagesToShow = pagesToShow
            });
        }
    }
}
