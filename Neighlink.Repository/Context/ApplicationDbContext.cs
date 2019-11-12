using Neighlink.Entity;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;


namespace Neighlink.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentCategory> PaymentCategories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<New> News { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                    //Por defecto todas nuestras entidades se crean con status true
                    ((BaseEntity)entity.Entity).Status = true;
                }

                if (entity.State == EntityState.Deleted)
                {
                    ((BaseEntity)entity.Entity).DeletedAt = now;
                }

                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}