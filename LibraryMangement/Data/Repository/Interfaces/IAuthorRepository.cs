using System.Collections.Generic;
using LibraryMangement.Data.Models;

namespace LibraryMangement.Data.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Auther>
    {
        IEnumerable<Auther> GetAllAuthersWithBooks();
        Auther GetAutherWithBooks(int bookId);
    }
}
