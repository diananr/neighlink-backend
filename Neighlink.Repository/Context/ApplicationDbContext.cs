using Neighlink.Entity;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity.Entity;

namespace Neighlink.Repository.Context
{
    public class ApplicationDbContext :DbContext
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
    }
}