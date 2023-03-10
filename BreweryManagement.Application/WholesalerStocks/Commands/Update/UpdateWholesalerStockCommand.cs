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
    public class UpdateWholesalerStockCommand : IRequest
    {
        public int Quantity { get; set; }
        public required Guid WholesalerId { get; set; }
        public required Guid BeerId { get; set; }
    }

    public class UpdateWholesalerStockCommandHandler : IRequestHandler<UpdateWholesalerStockCommand>
    {
        private readonly BreweryDb db;

        public UpdateWholesalerStockCommandHandler(BreweryDb db)
        {
            this.db = db;
        }

        async Task IRequestHandler<UpdateWholesalerStockCommand>.Handle(UpdateWholesalerStockCommand request, CancellationToken cancellationToken)
        {
            var stock = db.WholesalerStocks
                .FirstOrDefault(x => x.BeerId == request.BeerId && x.WholesalerId == request.WholesalerId);

            if (stock == null)
                throw new NotFoundException(nameof(WholesalerStock), new { beerId = request.BeerId, wholesaleId = request.WholesalerId });

            stock.Quantity = request.Quantity;
            await db.SaveChangesAsync();
        }
    }
}
