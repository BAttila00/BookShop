using BookShop.Dal.Entities;
using BookShop.Dal.EntityConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

//Ati: itt definiáljuk h milyen tábálák legyenek
//Valamint h azokban milyen adatok legyenek.
//Ezt lehet átültetni Add-Migration "migration name" parancsal egy migrációba, ami a migrations mappában fog megjelenni
//pl amikor at Add-Migration Initial parancsot adtuk ki akkor még csak a könyveket létrehozó rész volt itt (public DbSet<Book> Books { get; set; }) így az 20210819202649_Initial.cs fájlban még 
//csak egy Books táblát létrehozó metódus van.

//Viszont  miután betettük ide az "Ati: itt generálunk könyveket" komment alatti részt és kiadtuk az "Add-Migration InitialSeed" parancsot akkor létrejön a ............. fájl és ebben lesz azon rész
//ahol a Books táblát feltöltjük adatokkal.
namespace BookShop.Dal {
    public partial class BookShopDbContext : IdentityDbContext<User, IdentityRole<int>, int> {              //Ati: Ennek a paramétere azért int mert az Id típusa int kell most legyen (a User-ben).
        public BookShopDbContext() {

        }

        // ezen options-el az adatbázis-kapcsolat konfigurációs beállításait (timeout, connection string) állíthatjuk be.
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) {

        }

        /// <summary>
        /// A könyveket tároló adatbázis tábla
        /// </summary>
        //public DbSet<Book> Books { get; set; }


        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
//            if (!optionsBuilder.IsConfigured) {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookShopDb;Integrated Security=True");
//            }
        }

        //Ati: itt generálunk könyveket
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Address>(entity => {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("ZIP")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Author>(entity => {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FriendlyUrl).HasMaxLength(100);

                entity.Property(e => e.PhotoUrl).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity => {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FriendlyUrl)
                    .HasMaxLength(50);

                entity.Property(e => e.Order).HasMaxLength(20);

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Comment>(entity => {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_oduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Book>(entity => {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CoverUrl)
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FriendlyUrl).HasMaxLength(100);

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                //entity.Property(e => e.ShortDescription).IsRequired();

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Publisher");
            });

            modelBuilder.Entity<BookAuthor>(entity => {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookAuthor_Author");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthor)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookAuthor_Book");
            });

            modelBuilder.Entity<Publisher>(entity => {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FriendlyUrl).HasMaxLength(100);
            });

            modelBuilder.Entity<Rating>(entity => {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Book");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_User");
            });

            modelBuilder.Entity<User>(entity => {

                entity.ToTable("User");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100);


                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            });

            modelBuilder.Entity<UserAddress>(entity => {
                entity.HasKey(e => new { e.UserId, e.AddressId });

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_Address");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddress)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_User");
            });

            OnModelCreatingPartial(modelBuilder);

            //Ati: Ezekkel generáljuk le a tesztadatainkat az adatbázisba
            //Ezek csak lefuttatják a konfigurációs fájljainkat ahol felvettük az adatokat.
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
