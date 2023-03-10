using BreweryManagement.Application.Beers.Queries.GetBeersByBrewer;
using BreweryManagement.Application.Exceptions;
using BreweryManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagement.Application.Quotes.Queries.GetQuote
{
    public class GetQuoteQuery : IRequest<QuoteDto>
    {
        public required Guid WholesalerId { get; set; }
        public required BeerQuote[] Beers { get; set; }
    }
    public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, QuoteDto>
    {
        private readonly BreweryDb db;

        public GetQuoteQueryHandler(BreweryDb db)
        {
            this.db = db;
        }

        public async Task<QuoteDto> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
        {
            if (request.Beers == null || request.Beers.Length == 0) throw new NotValidException("The order cannot be empty");

            var wholesaler = await db.Wholesalers.FirstOrDefaultAsync(s => s.Id == request.WholesalerId);
            if (wholesaler == null) throw new NotValidException("The wholesaler must exist");

            var distinct = new HashSet<Guid>();
            decimal total = 0;
            foreach (var beerQuote in request.Beers)
            {
                if (!distinct.Add(beerQuote.BeerId)) throw new NotValidException("There can't be any duplicate in the order");
                var stock = await db.WholesalerStocks
                    .Include(i => i.Beer)
                    .Where(x => x.BeerId == beerQuote.BeerId && x.WholesalerId == request.WholesalerId)
                    .FirstOrDefaultAsync();
                if (stock == null) throw new NotValidException("wholesaler does not have this beer: " + beerQuote.BeerId);
                if (beerQuote.Quantity > stock.Quantity) throw new NotValidException("Beer quantity not sufficient: " + beerQuote.BeerId);

                //all good
                total += stock.Beer.Price * beerQuote.Quantity;
            }


            decimal totalQuantity = request.Beers.Sum(x => x.Quantity);
            decimal factor = 1;
            if (totalQuantity > 20) factor = 0.8m; //   20% discount
            else if (totalQuantity > 10) factor = 0.9m; //  10% discount

            return new QuoteDto
            {
                Total = total,
                NetTotal = total * factor,
            };
        }
    }
}
