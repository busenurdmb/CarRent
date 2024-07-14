using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarFilterSearchQueryHandler : IRequestHandler<GetCarFilterSearchQuery, List<GetCarQueryResult>>
    {
        private readonly CarRentContext _context;

        public GetCarFilterSearchQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarFilterSearchQuery request, CancellationToken cancellationToken)
        {
            // Kiralanmış araçların rezervasyonlarını getir
            var reservedCarIds = await _context.Reservations
                 .Where(r => (request.PickUpDate >= r.PickUpDate && request.PickUpDate <= r.DropOffDate) ||
                             (request.DropOffDate >= r.PickUpDate && request.DropOffDate <= r.DropOffDate))
                 .Select(r => r.CarID)
                 .ToListAsync();

            // Kiralanmamış araçları filtrele
            var query = _context.Cars.Where(c => !reservedCarIds.Contains(c.CarID) && c.LocationID== request.PickUpLocationID );  // Rezerve edilen araçları hariç tut

            var cars = await query
                .Select(c => new GetCarQueryResult
                {
                    CarID = c.CarID,
                    CarBrand = c.Brand.BrandName,
                    Model = c.Model,
                    Year = c.Year,
                    Color = c.Color,
                    FuelType = c.FuelType,
                    Transmission = c.Transmission,
                    Seats = c.Seats,
                    Doors = c.Doors,
                    LuggageCapacity = c.LuggageCapacity,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,


                })
                .ToListAsync();

            return cars;

        }
    }
}
