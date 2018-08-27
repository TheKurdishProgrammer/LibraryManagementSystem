using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Controllers.DatabaseRepository;
using LibraryMangement.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryMangement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly LibraryDbContext dbContext;

        public Repository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<T> FindAll()
        {
            return dbContext.Set<T>();
        }
       
        protected void SaveChanges() => dbContext.SaveChanges();

        public IEnumerable<T> FindAll(Func<T, bool> findPredicate)
        {
            return dbContext.Set<T>().Where(findPredicate);
        }

        public T FindById(int id)
        {
           return dbContext.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            dbContext.Add(entity);
            SaveChanges();
        }


        public void Delete(T entity)
        {
            dbContext.Remove(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {

            //todo baw shewash dabi

            //dbContext.Attach(entity);
//            dbContext.Entry(entity).Property("PropertyName").IsModified = true;
//            SaveChanges();

            dbContext.Entry(entity).State = EntityState.Modified;
        
            SaveChanges();
        }

        public int Count(Func<T, bool> countPredicat)
        {
            return dbContext.Set<T>().Where(countPredicat).Count();
        }
    }

   
}