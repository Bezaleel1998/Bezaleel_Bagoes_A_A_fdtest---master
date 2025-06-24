namespace Bezaleel_Bagoes_A_A_fdtest.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsEmailVerified { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
