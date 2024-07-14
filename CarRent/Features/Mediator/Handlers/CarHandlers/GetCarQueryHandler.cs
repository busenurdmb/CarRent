using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly CarRentContext _context;

        public GetCarQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cars.Select(x => new GetCarQueryResult
            {
                BrandID = x.BrandID,
                CarBrand = x.Brand.BrandName,
                 CarID = x.CarID,
                Color = x.Color,
                Doors = x.Doors,
                ImageUrl = x.ImageUrl,
                FuelType = x.FuelType,
                LuggageCapacity = x.LuggageCapacity,
                Model = x.Model,
                Price = x.Price,
                Year = x.Year,
                Seats = x.Seats,
                Transmission = x.Transmission,

            }).ToListAsync();

        }
    }
}
