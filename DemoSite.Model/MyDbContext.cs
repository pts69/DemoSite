using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DemoSite.Model.Entities;
using System.Threading;

namespace DemoSite.Model
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("Name=DefaultConnection")
        {
        }

        public static MyDbContext Create()
        {
            var ctx = new MyDbContext();
            ctx.Configuration.ProxyCreationEnabled = true;
            ctx.Configuration.LazyLoadingEnabled = true;

            return ctx;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<Vehicle> Vehicles { get; set; }



        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity == null) continue;
                var identityName = Thread.CurrentPrincipal.Identity.Name;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName;
                    entity.CreatedDate = now;
                }
                else
                {
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedBy = identityName;
                entity.UpdatedDate = now;
            }

            return base.SaveChanges();
            
        }


    }
}
