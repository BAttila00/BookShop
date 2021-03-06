using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookShop.Dal;
using BookShop.Dal.Dto;
using BookShop.Dal.Entities;
using BookShop.Dal.Services;
using Ganss.XSS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Pages
{
    public class BookModel : PageModel
    {
        private readonly BookService bookService;
        private readonly BookShopDbContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty( SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Comment NewComment { get; set; }

        [BindProperty]
        public BookHeader Book { get; set; }
        public List<Comment> Comments { get; set; }

        public string UserName { get; set; }

        public BookModel( BookService bookService, BookShopDbContext context, UserManager<User> userManager)
        {
            _context = context;
            this.bookService = bookService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Book = bookService.GetBook(Id);
            Comments = _context.Comment.Where(c => c.BookId == Id).ToList();
            NewComment = new Comment() { BookId = Id };
            UserName = _userManager.GetUserName(User);
        }

        public IActionResult OnPostCreateComment() {
            string userId = _userManager.GetUserId(User);
            if (ModelState.IsValid) {
                try {
                    NewComment.UserId = int.Parse(userId);
                    //NewComment.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    _context.Comment.Add(new Comment {
                        BookId = NewComment.BookId,
                        UserId = NewComment.UserId,
                        Type = NewComment.Type,
                        Text = new HtmlSanitizer().Sanitize(NewComment.Text),
                        CreatedDate = DateTime.Now
                    });
                    _context.SaveChanges();
                    return RedirectToPage("/Book", new { Id = NewComment.BookId });
                }
                catch (Exception ex) {
                    // TODO: Log
                    ModelState.AddModelError("", "A post l?trehoz?sa nem siker?lt");
                }
            }
            return Page();
        }
    }
}
