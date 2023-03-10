namespace BreweryManagement.Application.Beers.Queries.GetBeersByBrewer
{
    public class BeerDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public required Guid BrewerId { get; set; }
    }
}