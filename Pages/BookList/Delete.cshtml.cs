using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.BookList
{
    [RequireLogin]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToPage("/Auth/Login");

            Book = _db.Books.FirstOrDefault(b => b.BookId == id && b.UserId == userId);
            if (Book == null) return RedirectToPage("/BookList/Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Book == null) return RedirectToPage("/BookList/Index");

            var book = _db.Books.Find(Book.BookId);
            if (book != null) _db.Books.Remove(book);

            _db.SaveChanges();
            return RedirectToPage("/BookList/Index");
        }
    }
}
