using Microsoft.EntityFrameworkCore;
using TaskMonitorMinimalApi.Models;

namespace TaskMonitorMinimalApi.DA.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { Database.EnsureCreated(); }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasMany(s => s.AssignedObjectives)
            .WithMany(c => c.Performers)
            .UsingEntity(t=>t.ToTable("PerformersObjectives"));
            builder.Entity<User>()
                .HasMany(s => s.ManagedObjectives)
                .WithOne(c => c.Manager)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid(), Name = "Admin", AccessLevel = Enums.AccessLevel.Super },
                new Role { Id = Guid.NewGuid(), Name = "User", AccessLevel = Enums.AccessLevel.User }
                );


        }
    }

}
