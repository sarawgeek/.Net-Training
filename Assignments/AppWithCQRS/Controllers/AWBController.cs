using AppWithCQRS.Features.AWBFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppWithCQRS.Features.AWBFeatures.Commands;

namespace AppWithCQRS.Controllers
{
    public class AWBController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();

        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAWBCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteAWBCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Route("/update")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAWBCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Route("/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllAWBs()
        {
            return Ok(await Mediator.Send(new GetAllAWBsQuery()));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAWBByID(int id)
        {
            return Ok(await Mediator.Send(new GetAWBByIDQuery { AWBNumber = id }));
        }
    }
}
