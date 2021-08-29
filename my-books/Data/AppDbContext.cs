namespace my_books.Data
{
    using Microsoft.EntityFrameworkCore;
    using my_books.Data.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}