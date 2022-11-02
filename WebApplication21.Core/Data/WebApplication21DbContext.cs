using Microsoft.EntityFrameworkCore;
using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Data
{
    public class WebApplication21DbContext : DbContext
    {
        public WebApplication21DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReservation> BooksReservation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookReservation>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(p => p.BookId);

            builder.Entity<BookReservation>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);


        }
    }
}
