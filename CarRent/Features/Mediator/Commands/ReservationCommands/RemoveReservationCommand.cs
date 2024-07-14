using MediatR;

namespace CarRent.Features.Mediator.Commands.ReservationCommands
{
    public class RemoveReservationCommand : IRequest
    {
        public int ReservationID { get; set; }

        public RemoveReservationCommand(int reservationID)
        {
            ReservationID = reservationID;
        }
    }
}
