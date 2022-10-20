using CQRSDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.UserFeatures.Queries
{
    public class GetAllusersQuery: IRequest<IEnumerable<User>>
    {
        public class GetAllUsersQueryHandler: IRequestHandler<GetAllusersQuery, IEnumerable<User>>
        {
            private readonly IApplicationContext _context;
            public GetAllUsersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<User>> Handle(GetAllusersQuery request, CancellationToken cancellationToken)
            {
                var userList = await _context.Users.ToListAsync();

                if (userList == null) return null;

                return userList.AsReadOnly();
            }
        }
    }
}
