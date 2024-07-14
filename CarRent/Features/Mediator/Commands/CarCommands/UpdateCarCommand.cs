using CarRent.DAL.Entities;
using MediatR;

namespace CarRent.Features.Mediator.Commands.CarCommands
{
    public class UpdateCarCommand : IRequest
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int LocationID { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public int LuggageCapacity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
