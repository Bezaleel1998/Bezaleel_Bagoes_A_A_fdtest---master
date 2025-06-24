using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bezaleel_Bagoes_A_A_fdtest.Data;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class VerifyEmailModel : PageModel
    {
        private readonly AppDbContext _context;

        public VerifyEmailModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        public string Message { get; set; } = "";

        public async Task<IActionResult> OnGetAsync()
        {
            var verification = _context.EmailVerifications.FirstOrDefault(e => e.Token == Token);

            if (verification == null || (verification.ExpiresAt != null && verification.ExpiresAt < DateTime.Now))
            {
                Message = "Invalid or expired token.";
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == verification.UserId);
            if (user == null)
            {
                Message = "User not found.";
                return Page();
            }

            user.IsEmailVerified = true;
            _context.EmailVerifications.Remove(verification);
            await _context.SaveChangesAsync();

            Message = "Your email has been verified. You can now login.";
            return Page();
        }
    }
}
