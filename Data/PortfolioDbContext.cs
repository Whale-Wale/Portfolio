using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Models; // Đảm bảo namespace Models là chính xác

namespace PortfolioWebApp.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng (DbSet) mà EF Core sẽ quản lý
        public DbSet<About> About { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}