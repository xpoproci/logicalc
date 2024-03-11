using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LogicalcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<History> History { get; set; }

        public LogicalcDbContext(DbContextOptions<LogicalcDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}