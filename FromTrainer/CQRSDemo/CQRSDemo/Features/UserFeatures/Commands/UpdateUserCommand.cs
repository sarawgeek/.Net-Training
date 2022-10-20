using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.UserFeatures.Commands
{
    public class UpdateUserCommand: IRequest<int>
    {

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }


        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {

            private readonly IApplicationContext _context;

            public UpdateUserCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(u => u.UserId == request.UserId).FirstOrDefaultAsync();

                if (user == null) return default;

                user.FullName = request.FullName;
                user.Email= request.Email;
                user.Designation= request.Designation;

                await _context.SaveChanges();

                return user.UserId;
            }
        }

    }
}
