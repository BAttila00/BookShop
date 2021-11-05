using BookShop.Dal.Dto;
using BookShop.Dal.Entities;
using BookShop.Dal.Specifications;
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

        /*
        //TODO: Aszinkron is megy?
        public PagedResult<BookHeader> GetBooks(int? _pagenumber = 1) {     //Ati: ezzel azt érjük el h paraméter nélkül is hívható lesz ez a függvény.

            _pagenumber ??= 1;          //Ati: ha _pagenumber null akkor adjunk neki értékül 1-et
            int pageNumber = _pagenumber.Value;
            int pageSize = 5;

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

            int allResultsCount = books.Count();

            books = books.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<BookHeader> {
                AllResultsCount = allResultsCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Results = books
            };
        }
        */

        public PagedResult<BookHeader> GetBooks(PagerSpecification specification = null,     //Ati: ezzel azt érjük el h paraméter nélkül is hívható lesz ez a függvény.
            BooksSpecification booksSpecification = null) {

            //TODO: ha pl egy kategoriára rászűrök akkor nem működik megfelelően a lapozás
            specification ??= new PagerSpecification();                                         //ha specification null akkor hozzunk létre egyet
            if (specification.PageSize <= 0)
                specification.PageSize = 5;
            if (specification.PageNumber <= 0)
                specification.PageNumber = 1;

            IQueryable<Book> query = DbContext.Book;

            if(booksSpecification != null) {
                //Szürés
                if (booksSpecification.AuthorId.HasValue)
                    query = query.Where(b => b.BookAuthor.Any(ba => ba.AuthorId == booksSpecification.AuthorId));
                if (!string.IsNullOrWhiteSpace(booksSpecification?.Title))
                    query = query.Where(b => b.Title.Contains(booksSpecification.Title));
                if (booksSpecification.CategoryId.HasValue)
                    query = query.Where(b => b.CategoryId == booksSpecification.CategoryId || b.Category.ParentCategoryId == booksSpecification.CategoryId);

                //rendezés
                switch (booksSpecification.Order) {
                    case BooksSpecification.BookOrder.TitleAscending:
                        query = query.OrderBy(b => b.Title);
                        break;
                    case BooksSpecification.BookOrder.TitleDescending:
                        query = query.OrderByDescending(b => b.Title);
                        break;
                }
            }

            var books = query.Select(b => new BookHeader {             //itt hoz létre Book entitásból BookHeader típzusú "entitást".
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

            int allResultsCount = books.Count();

            //csak azon könyveket tartsuk meg amelyek az adott oldalon vannak.
            books = books.Skip((specification.PageNumber - 1) * specification.PageSize).Take(specification.PageSize).ToList();

            return new PagedResult<BookHeader> {
                AllResultsCount = allResultsCount,
                PageNumber = specification.PageNumber,
                PageSize = specification.PageSize,
                Results = books
            };
        }

        public BookHeader GetBook(int id) {
            var book = DbContext.Book
                .Where(b => b.Id == id)
                .Select(b => new BookHeader {             //itt hoz létre Book entitásból BookHeader típzusú "entitást".
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
                })
                .SingleOrDefault();

            return book;
        }
    }
}
