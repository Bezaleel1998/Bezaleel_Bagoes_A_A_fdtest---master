namespace Bezaleel_Bagoes_A_A_fdtest.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public int UserId { get; set; }

        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }

        public float? Rating { get; set; } // 1–5
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
