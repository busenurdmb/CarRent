
using MediatR;
using CarRent.Features.Mediator.Commands.ReservationCommands;
using CarRent.DAL.Context;

namespace ReservationRent.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly CarRentContext _context;

        public UpdateReservationCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Reservations.FindAsync(request.ReservationID);
            value.CarID = request.CarID;
            value.PickUpLocationID = request.PickUpLocationID;
            value.DropOffLocationID = request.DropOffLocationID;
            value.DropOffDate = request.DropOffDate;
            value.PickUpDate = request.PickUpDate;
            await _context.SaveChangesAsync();
        }
    }
}
