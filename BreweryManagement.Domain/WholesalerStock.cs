namespace BreweryManagement.Domain
{
    public class WholesalerStock
    {
        public Guid WholesalerId { get; set; }
        public Guid BeerId { get; set; }
        public decimal Quantity { get; set; }
        public Wholesaler Wholesaler { get; set; } = null!;
        public Beer Beer { get; set; } = null!;
    }
}
