using LibraryMangement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangement.Controllers.DatabaseRepository
{
    public class LibraryDbContext : DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
          
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
