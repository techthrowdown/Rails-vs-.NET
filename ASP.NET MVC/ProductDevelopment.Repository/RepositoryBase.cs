using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ProductDevelopment.Models;

namespace ProductDevelopment.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {

        protected IProductDevelopmentContext _ctx;
        private IDbSet<T> _set;

        public RepositoryBase(IProductDevelopmentContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.DbSet<T>();
        }

        public void Add(T entity)
        {
            _set.Add(entity);
            _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            _set.Attach(entity);
            _ctx.Update(entity);
            _ctx.SaveChanges();
        }

        public T Find(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> All()
        {
            return _set.ToList();
        }
    }
}
