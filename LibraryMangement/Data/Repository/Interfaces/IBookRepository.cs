using System;
using System.Collections.Generic;
using LibraryMangement.Data.Models;

namespace LibraryMangement.Data.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllBooksWithAuthor();
        IEnumerable<Book> GetAllBooksWithAuthor(Func<Book,bool> predicate);
        IEnumerable<Book> GetAllBooksWithAuthorAndBorrowor(Func<Book,bool> predicate);
    }
}
