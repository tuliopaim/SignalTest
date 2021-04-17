using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalTest.MVC.Domain.Entities;

namespace SignalTest.MVC.Data
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var user = modelBuilder.Entity<User>();
            
            user.Property(x => x.Nome).IsRequired().HasMaxLength(200);

            var tweet = modelBuilder.Entity<Tweet>();

            tweet.HasOne(x => x.User).WithMany();
            tweet.Property(x => x.Mensagem).IsRequired().HasMaxLength(280);
        }
    }
}