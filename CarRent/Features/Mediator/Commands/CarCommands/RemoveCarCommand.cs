using CarRent.DAL.Entities;
using MediatR;

namespace CarRent.Features.Mediator.Commands.CarCommands
{
    public class RemoveCarCommand : IRequest
    {
        public int CarID { get; set; }

        public RemoveCarCommand(int carID)
        {
            CarID = carID;
        }
    }
}
