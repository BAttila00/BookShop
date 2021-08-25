using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Dal.Entities
{
    public partial class Book
    {
        public Book()
        {
            Comment = new HashSet<Comment>();
            ProductAuthor = new HashSet<ProductAuthor>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FriendlyUrl { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public string Subtitle { get; set; }
        public string CoverUrl { get; set; }
        public string ShortDescription { get; set; }
        public int Price { get; set; }
        public int? DiscountPrice { get; set; }
        public int PublishYear { get; set; }
        public int PageNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SumRating { get; set; }
        public int RatingCount { get; set; }

        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<ProductAuthor> ProductAuthor { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
