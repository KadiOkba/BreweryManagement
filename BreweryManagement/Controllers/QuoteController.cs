using BreweryManagement.API.Controllers;
using BreweryManagement.Application.Beers.Commands.Create;
using BreweryManagement.Application.Beers.Commands.Delete;
using BreweryManagement.Application.Beers.Queries.GetBeersByBrewer;
using BreweryManagement.Application.Quotes.Queries.GetQuote;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagement.Controllers
{

    public class QuoteController : BaseController
    {

        private readonly ILogger<QuoteController> _logger;

        public QuoteController(ILogger<QuoteController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] GetQuoteQuery query)
        {
            return Ok(await Mediator.Send(query));
        }      
    }
}