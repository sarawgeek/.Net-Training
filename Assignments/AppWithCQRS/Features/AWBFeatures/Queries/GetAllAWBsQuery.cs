using AppWithCQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppWithCQRS.Features.AWBFeatures.Queries
{
    public class GetAllAWBsQuery : IRequest<IEnumerable<AWB>>
    {
        public class GetAllAWBsQueryHandler : IRequestHandler<GetAllAWBsQuery, IEnumerable<AWB>>
        {
            private readonly IApplicationContext _context;
            public GetAllAWBsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<AWB>> Handle(GetAllAWBsQuery request, CancellationToken cancellationToken)
            {
                var awbList = await _context.AWBs.ToListAsync();

                if (awbList == null) return null;

                return awbList.AsReadOnly();
            }
        }


    }
}
