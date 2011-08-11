using System.Data;
using System.Data.Entity;

namespace ProductDevelopment.Models
{
    public class ProductDevelopmentContext : DbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Project> Projects { get; set; }
        public IDbSet<Defect> Defects { get; set; }

        public virtual IDbSet<T> DbSet<T>() where T : EntityBase
        {
            return Set<T>();
        }

        public virtual void Update(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}