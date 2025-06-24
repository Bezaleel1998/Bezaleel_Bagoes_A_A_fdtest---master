using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class RegisterModel : PageModel
    {

        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public string? Message { get; set; }

        public class RegisterInput
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Users.Any(u => u.Email == Input.Email))
            {
                Message = "Email already registered.";
                return Page();
            }

            var user = new User
            {
                Name = Input.Name,
                Email = Input.Email,
                PasswordHash = UsefullFunctions.HashPassword(Input.Password),
                CreatedAt = DateTime.Now,
                IsEmailVerified = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = Guid.NewGuid().ToString();
            var verification = new EmailVerification
            {
                VerificationId = Guid.NewGuid().ToString(),
                UserId = user.UserId,
                Token = token,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddHours(24)
            };
            _context.Add(verification);
            await _context.SaveChangesAsync();

            var verifyUrl = Url.Page("/Auth/VerifyEmail", null, new { token = token }, Request.Scheme);
            Message = $"Registration successful. Please verify your email: <a href='{verifyUrl}'>Verify Email</a>";

            return Page();
        }
    }
}
