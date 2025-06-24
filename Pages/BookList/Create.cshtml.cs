using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.BookList
{
    [RequireLogin]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Input { get; set; } = new();

        public IActionResult OnPost()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Auth/Login");

            Input.UserId = userId.Value;
            Input.CreatedAt = DateTime.Now;

            _db.Books.Add(Input);
            _db.SaveChanges();

            return RedirectToPage("/BookList/Index");
        }
    }
}
