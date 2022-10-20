using AppWithCQRS.Models;
using MediatR;

namespace AppWithCQRS.Features.AWBFeatures.Queries
{
    public class GetAWBByIDQuery : IRequest<AWB>
    {
        public int AWBNumber { get; set; }

        public class GetAWBByIDQueryHandler : IRequestHandler<GetAWBByIDQuery, AWB>
        {
            private readonly IApplicationContext _context;
            public GetAWBByIDQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<AWB> Handle(GetAWBByIDQuery request, CancellationToken cancellationToken)
            {
               var awb = _context.AWBs.Where(a => a.AWBNumber == request.AWBNumber).FirstOrDefault();
                if (awb == null) return null;
                return awb;
            }
        }


    }
}
