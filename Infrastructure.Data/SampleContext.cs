using Core.DomainModel;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class SampleContext : DbContext //IdentityDbContext<ApplicationUser>
    {
        public SampleContext() : base("DefaultConnection")
        {
            Database.SetInitializer<SampleContext>(new SampleSeedInitializer());
        }

        public IDbSet<Project> Projects { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // use conventions when possible
        }
    }
}
