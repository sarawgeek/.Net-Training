using CQRSDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery: IRequest<User>
    {

        public int UserId { get; set; }

        public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, User>
        {

            private readonly IApplicationContext _context;
            public GetUserByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.UserId == request.UserId).FirstOrDefault();
                if (user == null) return null;

                return user;
            }
        }
    }
}
