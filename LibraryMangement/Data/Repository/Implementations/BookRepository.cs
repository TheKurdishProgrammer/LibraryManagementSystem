using System;
using System.Collections.Generic;
using System.Linq;
using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangement.Data.Repository.Implementations
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
       
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Book> GetAllBooksWithAuthor()
        {
            return dbContext.Books.Include(book=>book.Auther);
        }

        public IEnumerable<Book> GetAllBooksWithAuthor(Func<Book, bool> predicate)
        {
            return dbContext.Books.Include(b => b.Auther).Where(predicate);
        }


        public IEnumerable<Book> GetAllBooksWithAuthorAndBorrowor(Func<Book, bool> predicate)
        {
            return dbContext.Books.Include(b=>b.Auther).Include(b=>b.Borrower).Where(predicate);

        }
    }
}
