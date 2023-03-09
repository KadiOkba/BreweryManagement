using BreweryManagement.Domain.Common;

namespace BreweryManagement.Domain
{
    public class Wholesaler : BaseEntity
    {
        public Wholesaler(string name)
        {
            Stocks = new List<WholesalerStock>();
            Name = name;
        }
        public string Name { get; set; }
        public List<WholesalerStock> Stocks { get; set; }
    }
}
