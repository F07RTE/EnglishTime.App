using Microsoft.EntityFrameworkCore;

using EnglishTime.Data.Model;

namespace EnglishTime.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Story> Story { get; set; }
    }
}