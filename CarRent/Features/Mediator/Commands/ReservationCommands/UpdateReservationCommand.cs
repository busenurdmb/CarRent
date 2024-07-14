using MediatR;

namespace CarRent.Features.Mediator.Commands.ReservationCommands
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationID { get; set; }
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
