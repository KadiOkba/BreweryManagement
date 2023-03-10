using BreweryManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BreweryManagement.Application.Beers.Queries.GetBeersByBrewer
{
    public class GetBeersByBrewerQuery : IRequest<List<BeerDto>>
    {
        public Guid BrewerId { get; set; }

    }
    public class GetBeersByBrewerQueryHandler : IRequestHandler<GetBeersByBrewerQuery, List<BeerDto>>
    {
        private readonly BreweryDb db;
       
        public GetBeersByBrewerQueryHandler(BreweryDb db)
        {
            this.db = db;        
        }

        public async Task<List<BeerDto>> Handle(GetBeersByBrewerQuery request, CancellationToken cancellationToken)
        {
            if (request.BrewerId == Guid.Empty) return new List<BeerDto>();
            return await db.Beers.Where(x=>x.BrewerId == request.BrewerId)
                .Select(x=> new BeerDto
                {
                    Id = x.Id,
                    BrewerId= x.BrewerId,
                    Name= x.Name,
                    AlcoholContent= x.AlcoholContent,
                    Price= x.Price,
                    Quantity = x.Quantity
                })
                .ToListAsync();
        }
    }
}
