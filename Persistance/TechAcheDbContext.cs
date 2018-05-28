using Microsoft.EntityFrameworkCore;
using TechAche.Models;

namespace TechAche.Persistance
{
    public class TechAcheDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public TechAcheDbContext(DbContextOptions<TechAcheDbContext> options)
            : base(options)
        {
            
        }
    }
}