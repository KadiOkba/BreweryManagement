using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreweryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private IMediator? _mediator;
        protected IMediator Mediator => (_mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>()))!;

    }
}
