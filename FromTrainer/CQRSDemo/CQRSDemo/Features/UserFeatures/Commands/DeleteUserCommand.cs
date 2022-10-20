using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.UserFeatures.Commands
{


    public class DeleteUserCommand : IRequest<int>
    {

        public int UserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>{

            private readonly IApplicationContext _context;

            public DeleteUserCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(u => u.UserId == request.UserId).FirstOrDefaultAsync();

                if (user == null) return default;
                _context.Users.Remove(user);
                await _context.SaveChanges();

                return user.UserId;
            }
        }

    }
}
