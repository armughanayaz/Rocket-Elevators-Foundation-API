using Microsoft.EntityFrameworkCore;
namespace RocketApi.Models
{
    public class SecondApplicationContext : DbContext
    {
        public SecondApplicationContext(DbContextOptions<SecondApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<FactIntervention> fact_interventions { get; set; }
    }
}