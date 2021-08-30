using Microsoft.EntityFrameworkCore;

using EnglishTime.Data.Model;

namespace EnglishTime.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Tip> Tip { get; set; }
    }
}