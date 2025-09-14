using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AuthorAward>()
                .ToTable("AuthorAwardBridge") 
                .HasKey(authorAward => new { authorAward.AuthorId, authorAward.AwardId });

            
            modelBuilder.Entity<AuthorAward>()
                .HasOne(authorAward => authorAward.Author)
                .WithMany(authorAward => authorAward.AuthorAwards)
                .HasForeignKey(authorAward => authorAward.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<AuthorAward>()
                .HasOne(authorAward => authorAward.Award)
                .WithMany(authorAward => authorAward.AuthorAwards)
                .HasForeignKey(authorAward => authorAward.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Author>()
                .Property(author => author.DateOfBirth)
                .HasColumnName("Birthday");

            
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Publisher)
                .WithMany()
                .HasForeignKey(book => book.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany()
                .HasForeignKey(book => book.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
