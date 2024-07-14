using CarRent.DAL.Entities;
using MediatR;

namespace CarRent.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest
    {
        
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
