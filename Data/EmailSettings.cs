namespace Bezaleel_Bagoes_A_A_fdtest.Data
{
    public class EmailSettings
    {
        public string FromEmail { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string SmtpHost { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
