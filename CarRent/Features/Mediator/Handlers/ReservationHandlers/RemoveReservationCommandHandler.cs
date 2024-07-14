
using MediatR;
using CarRent.Features.Mediator.Commands.ReservationCommands;
using CarRent.DAL.Context;

namespace ReservationRent.Features.Mediator.Handlers.ReservationHandlers
{
    public class RemoveReservationCommandHandler : IRequestHandler<RemoveReservationCommand>
    {
        private readonly CarRentContext _context;

        public RemoveReservationCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveReservationCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Reservations.FindAsync(request.ReservationID);
            _context.Reservations.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
