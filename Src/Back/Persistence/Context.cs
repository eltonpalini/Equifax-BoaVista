using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) 
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.Amount).IsRequired();
                x.HasOne(o => o.Student).WithMany().IsRequired();
                x.HasOne(o => o.Course).WithMany().IsRequired();
                x.Property(p => p.IsActive).IsRequired();
                x.Property(p => p.CreatedAt).IsRequired();                
            });

            modelBuilder.Entity<Course>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.Name).IsRequired().HasMaxLength(500);
                x.Property(p => p.Price).IsRequired();
                x.Property(p => p.CreatedAt).IsRequired();
                x.Property(p => p.BillingType).IsRequired();
            });

            modelBuilder.Entity<Student>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.Name).IsRequired().HasMaxLength(500);
                x.Property(p => p.CreatedAt).IsRequired();
                x.HasOne(o => o.User).WithMany().IsRequired();
            });

            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(k => k.Id);
                x.Property(p => p.Login).IsRequired().HasMaxLength(100);
                x.Property(p => p.Password).IsRequired().HasMaxLength(100);
                x.Property(p => p.CreatedAt).IsRequired();
            });
        }

        public DbSet<Billing> Billings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
