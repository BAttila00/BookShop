using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Specifications {
    public class BooksSpecification{
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public BookOrder Order { get; set; } = BookOrder.TitleAscending;        //Alapértelmezetten ez legyen az értéke, szóval ha nem állítjuk be akkorse marad null, hanem ezt veszi fel.
        public enum BookOrder {                     //rendezési lehetöségek
            TitleAscending,
            TitleDescending
        }
    }
}
