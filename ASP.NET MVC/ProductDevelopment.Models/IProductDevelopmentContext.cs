using System.Data.Entity;
using System.Linq;

namespace ProductDevelopment.Models
{
    public interface IProductDevelopmentContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Project> Projects { get; set; }
        IDbSet<Defect> Defects { get; set; }
        IDbSet<T> DbSet<T>() where T : EntityBase;
        void Update(object entity);
        int SaveChanges();
    }
}