using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dal.Dto {

    //Ati: Célja, hogy az adatbázis sémában történt módosításokat elfedje.A service fájlok(pl BookService.cs) lekérik az adatbázisból az adatokat,
    //majd áttranszformálja a Dto mappában lévő fájlok mintájára(pl BookHeader.cs). Ezt fogja megkapni/látni a Web-es project(tehát a BookHeader.cs-t használja).
    //Ennek az a lényege h ha az adatbázisséma módosul attól még a Web project fusson(hiszen az csak a Dto-ban lévő fájlokra hivatkozik, amik nem módosultak).
    //Tehát ez kb egy transzformáció a  2 réteg között(WEB – DAL között).
    public class BookHeader {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int PublishYear { get; set; }
        public int PageNumber { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<string> AuthorNames { get; set; }
        public int? PublisherId { get; set; }
        public string PublisherName { get; set; }
        public int? CategoryId { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfRatings { get; set; }
        public double? AverageRating { get; set; }
    }
}
