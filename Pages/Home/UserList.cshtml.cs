using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Home
{
    [RequireLogin]
    public class UserListModel : PageModel
    {
        private readonly AppDbContext _db;

        public UserListModel(AppDbContext db)
        {
            _db = db;
        }

        public List<User> Users { get; set; } = new();

        [BindProperty(SupportsGet = true)] public string? SearchQuery { get; set; }
        [BindProperty(SupportsGet = true)] public string? Filter { get; set; }
        [BindProperty(SupportsGet = true)] public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }
        public const int PageSize = 5;

        public void OnGet()
        {
            var query = _db.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                var keyword = SearchQuery.ToLower();
                query = query.Where(u =>
                    (u.Name ?? "").ToLower().Contains(keyword) ||
                    u.Email.ToLower().Contains(keyword));
            }

            if (Filter == "verified")
                query = query.Where(u => u.IsEmailVerified);
            else if (Filter == "unverified")
                query = query.Where(u => !u.IsEmailVerified);

            int totalItems = query.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            int page = Math.Clamp(CurrentPage, 1, Math.Max(TotalPages, 1));

            Users = query
                .OrderBy(u => u.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

    }
}
