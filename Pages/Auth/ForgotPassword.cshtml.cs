using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bezaleel_Bagoes_A_A_fdtest.Data;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly AppDbContext _context;

        public ForgotPasswordModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
                Message = "Email not found.";
                return Page();
            }

            var token = Guid.NewGuid().ToString();
            var request = new PasswordResetRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                Token = token,
                UserId = user.UserId,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddMinutes(15)
            };

            _context.PasswordResetRequests.Add(request);
            await _context.SaveChangesAsync();

            var resetUrl = Url.Page("/Auth/ResetPassword", null, new { token = token }, Request.Scheme);
            Message = $"Password reset link: <a href='{resetUrl}'>{resetUrl}</a>";

            return Page();
        }
    }
}
