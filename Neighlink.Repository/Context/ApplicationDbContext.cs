using Neighlink.Entity;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity.Entity;

namespace Neighlink.Repository.Context
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Building> buildings { get; set; }
        public DbSet<Condominium> condominiums { get; set; }
        public DbSet<Plan> plans { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<PaymentCategory> paymentcategorys { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<Poll> polls { get; set; }
        public DbSet<Option> options { get; set; }
        public DbSet<News> news { get; set; } 

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
            .Property(p =>p.Name)
            .HasColumnName("Names")
            .HasMaxLength(50)
            .IsRequired();
            
             modelBuilder.Entity<Building>()
            .Property(p =>p.NumberOfHomes)
            .HasColumnName("NumberOfHomes")
            .HasMaxLength(4)
            .IsRequired();

            modelBuilder.Entity<PaymentCategory>()
            .Property(p =>p.Name)
            .HasColumnName("Names")
            .HasMaxLength(20)
            .IsRequired();

            modelBuilder.Entity<PaymentCategory>()
            .Property(p =>p.Description)
            .HasColumnName("Descriptions")
            .HasMaxLength(30)
            .IsRequired();

            modelBuilder.Entity<Role>()
            .Property(p =>p.Name)
            .HasColumnName("Names")
            .HasMaxLength(20)
            .IsRequired();

            modelBuilder.Entity<Role>()
            .Property(p =>p.Description)
            .HasColumnName("Descriptions")
            .HasMaxLength(30)
            .IsRequired();
        }
    }
}