using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.BookList
{
    [RequireLogin]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public List<Book> Books { get; set; } = new();

        [BindProperty(SupportsGet = true)] public string? RatingRange { get; set; }
        [BindProperty(SupportsGet = true)] public string? SearchQuery { get; set; }
        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public const int PageSize = 5;

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Auth/Login");

            var query = _db.Books.Where(b => b.UserId == userId);

            if (!string.IsNullOrWhiteSpace(RatingRange))
            {
                var parts = RatingRange.Split("-");
                if (parts.Length == 2 &&
                    float.TryParse(parts[0], out float min) &&
                    float.TryParse(parts[1], out float max))
                {
                    query = query.Where(b => b.Rating >= min && b.Rating < max);
                }
            }

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                var keyword = SearchQuery.ToLower();
                query = query.Where(b =>
                    (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(b.Author) && b.Author.ToLower().Contains(keyword))
                );
            }

            int totalItems = query.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            int page = Math.Clamp(CurrentPage, 1, Math.Max(TotalPages, 1));

            Books = query
                .OrderByDescending(b => b.CreatedAt)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return Page();
        }
    }
}
