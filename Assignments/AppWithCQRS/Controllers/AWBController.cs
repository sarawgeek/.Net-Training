using AppWithCQRS.Features.AWBFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppWithCQRS.Controllers
{
    public class AWBController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAWBByID(int id)
        {
            return Ok(await Mediator.Send(new GetAWBByIDQuery { AWBNumber = id }));
        }
    }
}
