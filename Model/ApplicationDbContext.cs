using Microsoft.EntityFrameworkCore;

namespace StajyerUygulamasi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Stajyer> Stajyer { get; set; }
        public DbSet<Experience> Experience { get; set; }
    }
}
