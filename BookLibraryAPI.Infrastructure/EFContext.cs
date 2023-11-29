using BookLibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Infrastructure
{
    public class EFContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Book
            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .HasMaxLength(250);

            modelBuilder.Entity<Book>()
                .Property(x => x.Author)
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(x => x.ISBN)
                .HasMaxLength(20);
        }
    }
}
