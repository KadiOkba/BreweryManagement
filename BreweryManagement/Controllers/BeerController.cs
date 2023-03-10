using BreweryManagement.API.Controllers;
using BreweryManagement.Application.Beers.Commands.Create;
using BreweryManagement.Application.Beers.Commands.Delete;
using BreweryManagement.Application.Beers.Queries.GetBeersByBrewer;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagement.Controllers
{

    public class BeerController : BaseController
    {

        private readonly ILogger<BeerController> _logger;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetBeersByBrewerQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBeerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delte([FromBody] DeleteBeerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}