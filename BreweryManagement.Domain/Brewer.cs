using BreweryManagement.Domain.Common;

namespace BreweryManagement.Domain
{
    public class Brewer : BaseEntity
    {
        public Brewer()
        {
            Beers = new List<Beer>();
        }
        public required string Name { get; set; }

        public List<Beer> Beers { get; set; }
    }
}
