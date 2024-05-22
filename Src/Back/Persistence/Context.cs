using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<Billing> Billings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
