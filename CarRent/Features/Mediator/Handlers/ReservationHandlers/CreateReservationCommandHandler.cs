using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using CarRent.Features.Mediator.Commands.CarCommands;
using CarRent.Features.Mediator.Commands.ReservationCommands;
using MediatR;

namespace CarRent.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly CarRentContext _context;

        public CreateReservationCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Reservation
            { 
            CarID = request.CarID,
            PickUpLocationID=request.PickUpLocationID,
            DropOffLocationID=request.DropOffLocationID,
            DropOffDate=request.DropOffDate,
            PickUpDate=request.PickUpDate,
            });
            await _context.SaveChangesAsync();

        }
    }
}
