using System.Data.Entity;
using System.Linq;
using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDbSet<T> _set;
        protected ProductDevelopmentContext _ctx;

        public Repository()
        {
            _ctx = new ProductDevelopmentContext();
            _set = _ctx.DbSet<T>();
        }

        public virtual void Add(T entity)
        {
            _set.Add(entity);
            _ctx.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _set.Remove(entity);
            _ctx.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _set.Attach(entity);
            _ctx.Update(entity);
            _ctx.SaveChanges();
        }

        public virtual T Find(int id)
        {
            return _set.Find(id);
        }

        public virtual IQueryable<T> All()
        {
            return _set;
        }
    }
}