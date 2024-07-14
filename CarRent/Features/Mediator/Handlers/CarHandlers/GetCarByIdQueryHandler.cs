using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarRent.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly CarRentContext _context;

        public GetCarByIdQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await _context.Cars.FindAsync(request.CarID);
            return new GetCarByIdQueryResult
            {
                BrandID=value.BrandID,
                CarID=value.CarID ,
                Color=value.Color,
                Doors=value.Doors,
                ImageUrl=value.ImageUrl,
                FuelType=value.FuelType,
                LuggageCapacity=value.LuggageCapacity,
                Model=value.Model,
                Price=value.Price,
                Year=value.Year,
                Seats=value.Seats,
                Transmission=value.Transmission,
               
            };

        }
    }
}
