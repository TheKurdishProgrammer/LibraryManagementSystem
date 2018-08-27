using System;
using System.Collections.Generic;

namespace LibraryMangement.Data.Repository.Interfaces
{
   public interface IRepository<T> where T : class
    {

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(Func<T,bool> findPredicate);

        T FindById(int id);

        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);

        int Count(Func<T,bool> countPredicat);
    }
}
