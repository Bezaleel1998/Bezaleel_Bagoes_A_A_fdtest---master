using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.BookList
{
    [RequireLogin]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Input { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToPage("/Auth/Login");

            var book = _db.Books.FirstOrDefault(b => b.BookId == id && b.UserId == userId);
            if (book == null) return RedirectToPage("/BookList/Index");

            Input = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToPage("/Auth/Login");

            var book = _db.Books.FirstOrDefault(b => b.BookId == Input.BookId && b.UserId == userId);
            if (book == null) return RedirectToPage("/BookList/Index");

            book.Title = Input.Title;
            book.Author = Input.Author;
            book.Description = Input.Description;
            book.ThumbnailUrl = Input.ThumbnailUrl;
            book.Rating = Input.Rating;

            _db.SaveChanges();
            return RedirectToPage("/BookList/Index");
        }
    }
}
