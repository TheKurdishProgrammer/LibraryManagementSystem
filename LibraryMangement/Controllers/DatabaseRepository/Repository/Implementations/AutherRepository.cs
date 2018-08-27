using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Controllers.DatabaseRepository;
using LibraryMangement.Data.Models;
using LibraryMangement.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangement.Data.Repository
{
    public class AutherRepository  : Repository<Auther>,IAuthorRepository
    {


        public AutherRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            
        }

      
        public IEnumerable<Auther> GetAllAuthersWithBooks()
        {
            return dbContext.Authers.Include(auther=>auther.Books);
        }

       
        public Auther GetAutherWithBooks(int id)
        {
            
            return dbContext.Authers.Where(auther => auther.AutherId ==  id).Include(auther=>auther.Books).FirstOrDefault();
        }

        //todo have time? implement this
        /* 
        public Auther GetAutherWithTheBookId(int id)
        {

        }
        */
    }
}