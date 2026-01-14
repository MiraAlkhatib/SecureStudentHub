using Microsoft.EntityFrameworkCore;
using SecureStudentHub.Models;

namespace SecureStudentHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
    }
}