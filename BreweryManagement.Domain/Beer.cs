using BreweryManagement.Domain.Common;

namespace BreweryManagement.Domain
{
    public class Beer : BaseEntity
    {
        public Beer()
        {
            WholesalerStocks = new List<WholesalerStock>();
        }
        public required string Name { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public required Guid BrewerId { get; set; }
        public Brewer Brewer { get; set; } = null!;
        public List<WholesalerStock> WholesalerStocks { get; set; }
    }
}
