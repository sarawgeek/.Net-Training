using CQRSDemo.Features.UserFeatures.Commands;
using CQRSDemo.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    public class UserController : Controller
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();



        [Route("/")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { UserId = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [Route("/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllusersQuery()));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { UserId = id}));
        }


    }
}
