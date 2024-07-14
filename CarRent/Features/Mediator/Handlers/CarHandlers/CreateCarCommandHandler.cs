using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using CarRent.Features.Mediator.Commands.CarCommands;
using MediatR;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly CarRentContext _context;

        public CreateCarCommandHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Car
            {
                BrandID = request.BrandID,
                Color = request.Color,
                Doors = request.Doors,
                FuelType = request.FuelType,
                ImageUrl = request.ImageUrl,
                LuggageCapacity = request.LuggageCapacity,
                Model = request.Model,
                Price = request.Price,
                Seats = request.Seats,
                Transmission = request.Transmission,
                Year = request.Year,
                LocationID=request.LocationID,
            });
           await  _context.SaveChangesAsync();

        }
    }
}
