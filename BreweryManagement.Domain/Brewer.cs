using BreweryManagement.Domain.Common;

namespace BreweryManagement.Domain
{
    public class Brewer : BaseEntity
    {
        public Brewer(string name)
        {
            Beers = new List<Beer>();
            Name = name;
        }
        public string Name { get; set; }

        public List<Beer> Beers { get; set; }
    }
}
