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
        public DbSet<About> About { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Intern> Intern { get; set; }
        public DbSet<InternSubmitted> InternSubmitted { get; set; }
    }
}
