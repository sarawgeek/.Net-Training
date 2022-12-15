using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppWithCQRS.Features.AWBFeatures.Commands
{
    public class DeleteAWBCommand : IRequest<int>
    {
        public int AWBNumber { get; set; }

        public class DeleteAWBCommandHandler : IRequestHandler<DeleteAWBCommand, int>
        {
            private readonly IApplicationContext _context;

            public DeleteAWBCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteAWBCommand request, CancellationToken cancellationToken)
            {
                var awb = await _context.AWBs.Where(u => u.AWBNumber == request.AWBNumber).FirstOrDefaultAsync();

                if (awb == null) return default;
                _context.AWBs.Remove(awb);
                await _context.SaveChanges();

                return awb.AWBNumber;
            }
        }
    }
}
