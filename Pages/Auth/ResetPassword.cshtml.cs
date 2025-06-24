using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Helpers;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        private readonly AppDbContext _context;

        public ResetPasswordModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var resetRequest = _context.PasswordResetRequests
                                .Where(r => r.Token == Token)
                                .Select(r => new {
                                    r.RequestId,
                                    r.Token,
                                    r.UserId
                                })
                                .AsEnumerable()
                                .Select(r => new PasswordResetRequest
                                {
                                    RequestId = r.RequestId,
                                    Token = r.Token,
                                    UserId = r.UserId
                                })
                                .FirstOrDefault();

            if (resetRequest == null || (resetRequest.ExpiresAt.HasValue && resetRequest.ExpiresAt < DateTime.Now))
            {
                Message = "Invalid or expired token.";
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserId == resetRequest.UserId);
            if (user == null)
            {
                Message = "User not found.";
                return Page();
            }

            user.PasswordHash = UsefullFunctions.HashPassword(NewPassword);
            _context.PasswordResetRequests.Remove(resetRequest);
            await _context.SaveChangesAsync();

            Message = "Password has been reset. You can now log in.";
            return Page();
        }
    }
}
