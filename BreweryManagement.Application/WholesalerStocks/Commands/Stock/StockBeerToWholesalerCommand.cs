using BreweryManagement.Application.Exceptions;
using BreweryManagement.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagement.Application.WholesalerStocks.Commands.Stock
{
    public class StockBeerToWholesalerCommand : IRequest
    {
        public int Quantity { get; set; }
        public required Guid WholesalerId { get; set; }
        public required Guid BeerId { get; set; }
    }

    public class StockBeerToWholesalerCommandHandler : IRequestHandler<StockBeerToWholesalerCommand>
    {
        private readonly BreweryDb db;

        public StockBeerToWholesalerCommandHandler(BreweryDb db)
        {
            this.db = db;
        }

        async Task IRequestHandler<StockBeerToWholesalerCommand>.Handle(StockBeerToWholesalerCommand request, CancellationToken cancellationToken)
        {
            var beerExist = db.Beers.Any(b => b.Id == request.BeerId);
            if (!beerExist) throw new NotValidException("check your entry");

            var wholesalerExist = db.Wholesalers.Any(s => s.Id == request.WholesalerId);
            if (!wholesalerExist) throw new NotValidException("check your entry");

            var stock = db.WholesalerStocks
               .FirstOrDefault(x => x.BeerId == request.BeerId && x.WholesalerId == request.WholesalerId);

            if (stock != null) stock.Quantity += request.Quantity;
            else
                db.WholesalerStocks.Add(new WholesalerStock
                {
                    BeerId = request.BeerId,
                    WholesalerId = request.WholesalerId,
                    Quantity = request.Quantity
                });

            await db.SaveChangesAsync();
        }
    }
}
