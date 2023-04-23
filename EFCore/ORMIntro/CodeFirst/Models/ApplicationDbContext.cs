using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-T5A7CLB;Database=CodeFirst;Trusted_Connection=True;Encrypt=False");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}