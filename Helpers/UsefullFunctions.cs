using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Bezaleel_Bagoes_A_A_fdtest.Helpers
{
    public static class UsefullFunctions
    {

        public static IActionResult RedirectIfNotLoggedIn(HttpContext httpContext)
        {
            var userId = httpContext.Session.GetInt32("UserId");
            if (userId == null)
                return new RedirectToPageResult("/Auth/Login");
            else
                return new RedirectToPageResult("/Home/Index");
        }

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

    }
}
