using BreweryManagement.Domain.Common;

namespace BreweryManagement.Domain
{
    public class Wholesaler : BaseEntity
    {
        public Wholesaler()
        {
            Stocks = new List<WholesalerStock>();
        }
        public required string Name { get; set; }
        public List<WholesalerStock> Stocks { get; set; }
    }
}
