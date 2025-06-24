using Bezaleel_Bagoes_A_A_fdtest.Pages.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Home
{
    [RequireLogin]
    public class IndexModel : PageModel
    {
        public string Name { get; set; } = "";
        public string DateTimeLocal { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsVerified { get; set; }

        public IActionResult OnGet()
        {
            DateTimeLocal = DateTime.Now.ToString();

            Name = HttpContext.Session.GetString("UserName") ?? "";
            Email = HttpContext.Session.GetString("UserEmail") ?? "";
            IsVerified = (HttpContext.Session.GetString("IsEmailVerified") == "true");

            return Page();
        }
    }
}
