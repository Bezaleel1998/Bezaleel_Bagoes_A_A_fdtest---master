using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class ChangePasswordModel : PageModel
    {
        private readonly AppDbContext _db;

        public ChangePasswordModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string OldPassword { get; set; }
        [BindProperty]
        public string NewPassword { get; set; }

        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToPage("/Auth/Login");

            var user = _db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return RedirectToPage("/Auth/Login");

            if (user.PasswordHash != UsefullFunctions.HashPassword(OldPassword))
            {
                Message = "Old password is incorrect.";
                return Page();
            }

            user.PasswordHash = UsefullFunctions.HashPassword(NewPassword);
            await _db.SaveChangesAsync();

            Message = "Password changed successfully.";
            return Page();
        }
    }
}
