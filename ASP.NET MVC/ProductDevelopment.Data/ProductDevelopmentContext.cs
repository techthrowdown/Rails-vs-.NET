using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ProductDevelopment.Models;

namespace ProductDevelopment.Data
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

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;

            //modelBuilder.Entity<User>().Map(m => m.ToTable("tbl_User"));
            //modelBuilder.Entity<Project>().Map(m => m.ToTable("tbl_Project"));
            //modelBuilder.Entity<Defect>().Map(m => m.ToTable("tbl_Defect"));

            ////m2m for Users-Projects
            //modelBuilder.Entity<Project>()
            //  .HasMany(p => p.Users)
            //  .WithMany(u => u.Projects)
            //  .Map(mc =>
            //  {
            //      mc.ToTable("jn_Project_User");
            //      mc.MapLeftKey("ProjectId");
            //      mc.MapRightKey("UserId");
            //  });

            ////one2m for Projects-Defects
            //modelBuilder.Entity<Project>()
            //    .HasMany(p => p.Defects);

            //modelBuilder.Entity<Defect>()
            //    .HasRequired(d => d.CreatorUserId);

            //modelBuilder.Entity<Defect>()
            //    .HasRequired(d => d.AssignedToUserId);


        }
    }
}
