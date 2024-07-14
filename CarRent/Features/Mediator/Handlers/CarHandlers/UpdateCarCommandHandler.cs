using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using CarRent.Features.Mediator.Commands.CarCommands;
using MediatR;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly CarRentContext _context;

        public UpdateCarCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var value =await _context.Cars.FindAsync(request.CarID);
            value.BrandID = request.BrandID;
            value.CarID = request.CarID;
            value.Color = request.Color;
            value.Doors = request.Doors;
            value.ImageUrl = request.ImageUrl;
            value.FuelType = request.FuelType;
            value.LuggageCapacity = request.LuggageCapacity;
            value.Model = request.Model;
            value.Price = request.Price;
            value.Year = request.Year;
            value.Seats = request.Seats;
            value.Transmission = request.Transmission;
           
            await _context.SaveChangesAsync();
        }
    }
}
