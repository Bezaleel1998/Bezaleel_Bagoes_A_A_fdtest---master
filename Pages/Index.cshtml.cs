using Bezaleel_Bagoes_A_A_fdtest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return UsefullFunctions.RedirectIfNotLoggedIn(HttpContext);
        }
    }
}
