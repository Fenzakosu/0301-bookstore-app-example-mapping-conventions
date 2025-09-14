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

            // Seed data
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Authors (5)
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "Milorad Pavić", Biography = "Srpski pisac postmodernizma, autor Hazarskog rečnika", DateOfBirth = new DateTime(1929, 10, 15, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 2, FullName = "Ivo Andrić", Biography = "Nobelovac za književnost, autor Na Drini ćuprija", DateOfBirth = new DateTime(1892, 10, 9, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 3, FullName = "Danilo Kiš", Biography = "Jedan od najvažnijih srpskih pisaca XX veka", DateOfBirth = new DateTime(1935, 2, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 4, FullName = "Meša Selimović", Biography = "Bosanski pisac, autor romana Derviš i smrt", DateOfBirth = new DateTime(1910, 4, 26, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 5, FullName = "Borislav Pekić", Biography = "Srpski pisac, dramaturg i scenarista", DateOfBirth = new DateTime(1930, 2, 4, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Publishers (3)
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Prosveta", Address = "Terazije 16, Beograd", Website = "https://www.prosveta.rs" },
                new Publisher { Id = 2, Name = "Dereta", Address = "Žorža Klemansoa 22, Beograd", Website = "https://www.dereta.rs" },
                new Publisher { Id = 3, Name = "Stubovi kulture", Address = "Knez Mihailova 18, Beograd", Website = "https://www.stubovi-kulture.rs" }
            );

            // Seed Awards (4)
            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "NIN-ova nagrada", Description = "Najpoznatija književna nagrada u Srbiji", StartYear = 1954 },
                new Award { Id = 2, Name = "Andrićeva nagrada", Description = "Nagrada za najbolje ostvarenje u oblasti pripovedne proze", StartYear = 1975 },
                new Award { Id = 3, Name = "Vukova nagrada", Description = "Nagrada za životno delo u oblasti književnosti", StartYear = 1994 },
                new Award { Id = 4, Name = "Borislav Pekić", Description = "Nagrada za roman godine", StartYear = 2000 }
            );

            // Seed Books (12)
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Hazarski rečnik", PageCount = 320, PublishedDate = new DateTime(1984, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-1", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Unutrašnja strana vetra", PageCount = 280, PublishedDate = new DateTime(1991, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-2", AuthorId = 1, PublisherId = 2 },
                new Book { Id = 3, Title = "Predeo slikan čajem", PageCount = 200, PublishedDate = new DateTime(1988, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-3", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 4, Title = "Na Drini ćuprija", PageCount = 420, PublishedDate = new DateTime(1945, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-4", AuthorId = 2, PublisherId = 1 },
                new Book { Id = 5, Title = "Travnička hronika", PageCount = 380, PublishedDate = new DateTime(1942, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-5", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 6, Title = "Prokleta avlija", PageCount = 250, PublishedDate = new DateTime(1954, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-6", AuthorId = 2, PublisherId = 1 },
                new Book { Id = 7, Title = "Bašta, pepeo", PageCount = 180, PublishedDate = new DateTime(1965, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-7", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 8, Title = "Grobnica za Borisa Davidoviča", PageCount = 150, PublishedDate = new DateTime(1976, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-8", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 9, Title = "Derviš i smrt", PageCount = 350, PublishedDate = new DateTime(1966, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-9", AuthorId = 4, PublisherId = 1 },
                new Book { Id = 10, Title = "Tvrđava", PageCount = 400, PublishedDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-10", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 11, Title = "Hodočašće Arsenija Njegovana", PageCount = 600, PublishedDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-11", AuthorId = 5, PublisherId = 2 },
                new Book { Id = 12, Title = "Atlantida", PageCount = 450, PublishedDate = new DateTime(1988, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "978-86-11-12345-12", AuthorId = 5, PublisherId = 1 }
            );

            // Seed AuthorAward relationships (15)
            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { AuthorId = 1, AwardId = 1, YearAwarded = 1984 }, // Pavić - NIN
                new AuthorAward { AuthorId = 1, AwardId = 2, YearAwarded = 1985 }, // Pavić - Andrićeva
                new AuthorAward { AuthorId = 1, AwardId = 3, YearAwarded = 2009 }, // Pavić - Vukova
                new AuthorAward { AuthorId = 2, AwardId = 1, YearAwarded = 1961 }, // Andrić - NIN
                new AuthorAward { AuthorId = 2, AwardId = 3, YearAwarded = 1982 }, // Andrić - Vukova
                new AuthorAward { AuthorId = 3, AwardId = 1, YearAwarded = 1976 }, // Kiš - NIN
                new AuthorAward { AuthorId = 3, AwardId = 2, YearAwarded = 1977 }, // Kiš - Andrićeva
                new AuthorAward { AuthorId = 3, AwardId = 3, YearAwarded = 1983 }, // Kiš - Vukova
                new AuthorAward { AuthorId = 4, AwardId = 1, YearAwarded = 1966 }, // Selimović - NIN
                new AuthorAward { AuthorId = 4, AwardId = 2, YearAwarded = 1967 }, // Selimović - Andrićeva
                new AuthorAward { AuthorId = 4, AwardId = 3, YearAwarded = 1987 }, // Selimović - Vukova
                new AuthorAward { AuthorId = 5, AwardId = 1, YearAwarded = 1970 }, // Pekić - NIN
                new AuthorAward { AuthorId = 5, AwardId = 2, YearAwarded = 1971 }, // Pekić - Andrićeva
                new AuthorAward { AuthorId = 5, AwardId = 4, YearAwarded = 2001 }, // Pekić - Borislav Pekić
                new AuthorAward { AuthorId = 1, AwardId = 4, YearAwarded = 2002 }  // Pavić - Borislav Pekić
            );
        }
    }

}
