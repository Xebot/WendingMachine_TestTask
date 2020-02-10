using Microsoft.EntityFrameworkCore;
using WendingDomain.Entities;

namespace WendingDomain
{
    public class WendingDbContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<WendingMachine> WendingMachine {get; set;}
        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinStorage> Storage { get; set; }

        
        public WendingDbContext(DbContextOptions<WendingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<WendingMachine>()
                .HasMany(a => a.Drinks)
                .WithOne(c => c.WendingMachine)
                .OnDelete(DeleteBehavior.Cascade);
            
        }        
    }
}
