using Bezaleel_Bagoes_A_A_fdtest.Data;
using Bezaleel_Bagoes_A_A_fdtest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Bezaleel_Bagoes_A_A_fdtest.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginInput Input { get; set; } = new();

        public string? Message { get; set; }

        public class LoginInput
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
                return RedirectToPage("/Home/Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var hash = UsefullFunctions.HashPassword(Input.Password);

            var user = _context.Users.FirstOrDefault(u =>
                u.Email == Input.Email && u.PasswordHash == hash);

            if (user == null)
            {
                Message = "Invalid email or password.";
                return Page();
            }

            if (!user.IsEmailVerified)
            {
                Message = "Email not verified.";
                return Page();
            }

            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.Name ?? "");
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("IsEmailVerified", user.IsEmailVerified ? "true" : "false");

            return RedirectToPage("/Home/Index");
        }
    }
}
