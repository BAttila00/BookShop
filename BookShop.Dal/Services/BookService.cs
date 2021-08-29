using BookShop.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Ati: itt lesznek a fájlok amik leképezik a tényleges adatbázist a Dto fájlok mintájára.
//Pl a BookService.cs a BookHeader.cs mintájára képezi le a Book.cs entitásunkat.
//BookService-t e kell majd regisztrálni a webes projektben (Startup.cs) a servicek közé

namespace BookShop.Dal.Services {
    public class BookService {

        public BookShopDbContext DbContext { get; }
        public BookService(BookShopDbContext dbContext) {
            DbContext = dbContext;
        }

        //TODO: Aszinkron is megy?
        public IEnumerable<BookHeader> GetBooks() {
            var books = DbContext.Book.Select(b => new BookHeader {             //itt hoz létre Book entitásból BookHeader típzusú "entitást".
                AuthorNames = b.BookAuthor.Select(ba => ba.Author.DisplayName).ToList(),
                AuthorIds = b.BookAuthor.Select(ba => ba.AuthorId).ToList(),
                AverageRating = b.Rating.Select(r => r.Value).Average(),
                CategoryId = b.CategoryId,
                DiscountedPrice = b.DiscountPrice,
                Id = b.Id,
                NumberOfComments = b.Comment.Count(),
                PageNumber = b.PageNumber,
                NumberOfRatings = b.Rating.Count(),
                Price = b.Price,
                PublisherName = b.Publisher.DisplayName,
                PublisherId = b.PublisherId,
                PublishYear = b.PublishYear,
                ShortDescription = b.ShortDescription,
                Subtitle = b.Subtitle,
                Title = b.Title
            }).ToList();

            return books;
        }
    }
}
