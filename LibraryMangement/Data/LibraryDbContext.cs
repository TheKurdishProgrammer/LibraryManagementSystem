using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangement.Data
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
