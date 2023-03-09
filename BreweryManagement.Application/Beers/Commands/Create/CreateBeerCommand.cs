using BreweryManagement.Persistence;
using MediatR;

namespace BreweryManagement.Application.Beers.Commands.Create
{
    public class CreateBeerCommand : IRequest
    {
        public required string Name { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public required Guid BrewerId { get; set; }
    }

    public class CreateBeerCommandHandler : IRequestHandler<CreateBeerCommand>
    {
        private readonly BreweryDb db;

        public CreateBeerCommandHandler(BreweryDb db)
        {
            this.db = db;
        }

        async Task IRequestHandler<CreateBeerCommand>.Handle(CreateBeerCommand request, CancellationToken cancellationToken)
        {
            db.Beers.Add(new Beer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                AlcoholContent = request.AlcoholContent,
                Price = request.Price,
                Quantity = request.Quantity,
                BrewerId = request.BrewerId
            });
            await db.SaveChangesAsync();
        }
    }
}
