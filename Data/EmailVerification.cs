namespace Bezaleel_Bagoes_A_A_fdtest.Data
{
    public class EmailVerification
    {
        public string VerificationId { get; set; } = null!;
        public int UserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public User User { get; set; } = null!;
    }
}
