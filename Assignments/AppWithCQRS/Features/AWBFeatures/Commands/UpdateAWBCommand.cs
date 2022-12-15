using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppWithCQRS.Features.AWBFeatures.Commands
{
    public class UpdateAWBCommand : IRequest<int>
    {
        public int AWBNumber { get; set; }

        public string Status_Type { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }

        public class UpdateAWBCommandHandler : IRequestHandler<UpdateAWBCommand, int>
        {
            private readonly IApplicationContext _context;

            public UpdateAWBCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateAWBCommand request, CancellationToken cancellationToken)
            {
                var awb = await _context.AWBs.Where(u => u.AWBNumber == request.AWBNumber).FirstOrDefaultAsync();

                if (awb == null) return default;

                if(request.Reciever != null)
                awb.Reciever = request.Reciever;

                if (request.Status_Type != null)
                awb.Status_Type = request.Status_Type;

                if (request.Sender != null)
                awb.Sender = request.Sender;

                await _context.SaveChanges();

                return awb.AWBNumber;
            }
        }
    }
}
