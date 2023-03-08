using BreweryManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagement.Persistence
{
    public class BreweryDb : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
    }
}
