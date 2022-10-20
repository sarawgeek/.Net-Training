using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Features.UserFeatures.Commands
{
    public class CreateUserCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {

            private readonly IApplicationContext _context;

            public CreateUserCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User();
                user.FullName = request.FullName;
                user.Email = request.Email ;
                user.Designation= request.Designation;

                _context.Users.Add(user);
                await _context.SaveChanges();
                return user.UserId;

            }
        }

    }
}
