using Bezaleel_Bagoes_A_A_fdtest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.BookList.Landing
{
    public class BooksModel : PageModel
    {
        private readonly AppDbContext _db;

        public BooksModel(AppDbContext db)
        {
            _db = db;
        }

        public List<Book> Books { get; set; } = new();
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)] public string? Author { get; set; }
        [BindProperty(SupportsGet = true)] public string? RatingRange { get; set; }
        [BindProperty(SupportsGet = true)] public DateTime? FromDate { get; set; }
        [BindProperty(SupportsGet = true)] public DateTime? ToDate { get; set; }
        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;

        private const int PageSize = 5;

        public void OnGet()
        {
            var query = _db.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Author))
                query = query.Where(b => b.Author != null && b.Author.Contains(Author));

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

            if (FromDate.HasValue)
                query = query.Where(b => b.CreatedAt >= FromDate.Value);

            if (ToDate.HasValue)
                query = query.Where(b => b.CreatedAt <= ToDate.Value);

            int totalItems = query.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            Page = Math.Clamp(CurrentPage, 1, Math.Max(TotalPages, 1));

            Books = query
                .OrderByDescending(b => b.CreatedAt)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}
