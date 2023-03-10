using System.Numerics;

namespace BreweryManagement.Application.Quotes.Queries.GetQuote
{
    public class QuoteDto
    {
        public decimal Total { get; set; }
        public decimal Discount => Total - NetTotal;
        public decimal NetTotal { get; set; }
    }
}
