using Microsoft.EntityFrameworkCore;

namespace Bezaleel_Bagoes_A_A_fdtest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Table
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasColumnName("password_hash");
            modelBuilder.Entity<User>().Property(u => u.IsEmailVerified).HasColumnName("is_email_verified");
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasColumnName("created_at");

            // Email Verifications Table
            modelBuilder.Entity<EmailVerification>().ToTable("email_verifications");
            modelBuilder.Entity<EmailVerification>().HasKey(e => e.VerificationId);
            modelBuilder.Entity<EmailVerification>().Property(e => e.VerificationId)
                .HasColumnName("verification_id")
                .HasConversion<string>();
            modelBuilder.Entity<EmailVerification>().Property(e => e.UserId).HasColumnName("user_id");
            modelBuilder.Entity<EmailVerification>().Property(e => e.Token).HasColumnName("token");
            modelBuilder.Entity<EmailVerification>().Property(e => e.CreatedAt).HasColumnName("created_at");
            modelBuilder.Entity<EmailVerification>().Property(e => e.ExpiresAt).HasColumnName("expires_at");

            modelBuilder.Entity<EmailVerification>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            // Request Reset Password
            modelBuilder.Entity<PasswordResetRequest>().ToTable("password_reset_requests");
            modelBuilder.Entity<PasswordResetRequest>().HasKey(p => p.RequestId);
            modelBuilder.Entity<PasswordResetRequest>().Property(p => p.RequestId)
                .HasColumnName("request_id")
                .HasConversion<string>();
            modelBuilder.Entity<PasswordResetRequest>().Property(p => p.UserId).HasColumnName("user_id");
            modelBuilder.Entity<PasswordResetRequest>().Property(p => p.Token).HasColumnName("token");
            modelBuilder.Entity<PasswordResetRequest>().Property(p => p.CreatedAt).HasColumnName("created_at");
            modelBuilder.Entity<PasswordResetRequest>().Property(p => p.ExpiresAt).HasColumnName("expires_at");

            modelBuilder.Entity<PasswordResetRequest>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            //book table
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Book>().Property(b => b.BookId).HasColumnName("book_id");
            modelBuilder.Entity<Book>().Property(b => b.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Book>().Property(b => b.Title).HasColumnName("title");
            modelBuilder.Entity<Book>().Property(b => b.Author).HasColumnName("author");
            modelBuilder.Entity<Book>().Property(b => b.Description).HasColumnName("description");
            modelBuilder.Entity<Book>().Property(b => b.ThumbnailUrl).HasColumnName("thumbnail_url");
            modelBuilder.Entity<Book>().Property(b => b.Rating).HasColumnName("rating");
            modelBuilder.Entity<Book>().Property(b => b.CreatedAt).HasColumnName("created_at");

            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

        }

    }
}
