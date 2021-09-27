using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Dto {
    public class PagedResult<T> {
        public IEnumerable<T> Results { get; set; }     //Ati: ebben lesznek az elemek, pl a bookHeader elemek
        public int AllResultsCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
