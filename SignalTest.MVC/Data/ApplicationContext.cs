using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<UserInstance> UserInstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserInstance>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}