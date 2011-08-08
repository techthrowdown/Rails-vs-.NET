using System.Collections.Generic;
using ProductDevelopment.Models;

namespace ProductDevelopment.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Find(int id);
        IEnumerable<T> All();
    }
}