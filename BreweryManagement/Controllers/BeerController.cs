using BreweryManagement.API.Controllers;
using BreweryManagement.Application.Beers.Commands.Create;
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBeerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

    }
}