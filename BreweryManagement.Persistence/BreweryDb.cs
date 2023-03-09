using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using BreweryManagement.Persistence.Configurations;

namespace BreweryManagement.Persistence
{
    public class BreweryDb : DbContext
    {
        public BreweryDb(DbContextOptions<BreweryDb> options) : base(options)
        {

        }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<WholesalerStock> WholesalerStocks { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Client>(new ClientConfigurations().Configure);
            builder.Entity<Beer>(new BeerConfigurations().Configure);
            builder.Entity<Brewer>(new BrewerConfigurations().Configure);
            builder.Entity<WholesalerStock>(new WholesalerStockConfigurations().Configure);
            builder.Entity<Wholesaler>(new WholesalerConfigurations().Configure);
        }
    }
}
