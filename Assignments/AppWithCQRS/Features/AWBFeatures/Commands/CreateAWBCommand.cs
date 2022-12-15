using AppWithCQRS.Models;
using MediatR;

namespace AppWithCQRS.Features.AWBFeatures.Commands
{
    public class CreateAWBCommand : IRequest<int>
    {
        //public int AWBNumber { get; set; }

        public string Status_Type { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }

        public class CreateAWBCommandHandler : IRequestHandler<CreateAWBCommand, int>
        {
            private readonly IApplicationContext _context;

            public CreateAWBCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateAWBCommand request, CancellationToken cancellationToken)
            {
                var awb = new AWB();
                awb.Reciever = request.Reciever;
                awb.Status_Type = request.Status_Type;
                awb.Sender = request.Sender;

                _context.AWBs.Add(awb);
                await _context.SaveChanges();

                return awb.AWBNumber;
            }
        }
    }
}
