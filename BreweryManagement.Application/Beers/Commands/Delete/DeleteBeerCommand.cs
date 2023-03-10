using BreweryManagement.Application.Exceptions;
using BreweryManagement.Persistence;
using MediatR;

namespace BreweryManagement.Application.Beers.Commands.Delete
{
    public class DeleteBeerCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand>
    {
        private readonly BreweryDb db;

        public DeleteBeerCommandHandler(BreweryDb db)
        {
            this.db = db;
        }

        async Task IRequestHandler<DeleteBeerCommand>.Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = db.Beers.FirstOrDefault(x => x.Id == request.Id);
            if (beer == null) throw new NotFoundException(nameof(beer), request.Id);
            db.Beers.Remove(beer);
            await db.SaveChangesAsync();
        }
    }
}
