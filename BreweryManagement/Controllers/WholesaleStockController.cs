using BreweryManagement.API.Controllers;
using BreweryManagement.Application.Beers.Commands.Create;
using BreweryManagement.Application.Beers.Commands.Delete;
using BreweryManagement.Application.Beers.Queries.GetBeersByBrewer;
using BreweryManagement.Application.WholesalerStocks.Commands.Stock;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagement.Controllers
{

    public class WholesaleStockController : BaseController
    {

        private readonly ILogger<WholesaleStockController> _logger;

        public WholesaleStockController(ILogger<WholesaleStockController> logger)
        {
            _logger = logger;
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockBeerToWholesalerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWholesalerStockCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}