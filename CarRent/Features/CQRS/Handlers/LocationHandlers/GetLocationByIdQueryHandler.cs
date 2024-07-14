using CarRent.DAL.Context;
using CarRent.Features.CQRS.Queries.LocationQueries;
using CarRent.Features.CQRS.Results.BrandResults;
using CarRent.Features.CQRS.Results.LocationResults;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler
    {
        private readonly CarRentContext _context;

        public GetLocationByIdQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public GetLocationByIdQueryResult Handle(GetLocationByIdQuery query)
        {
            var values = _context.Locations.Find(query.LocationID);
            return new GetLocationByIdQueryResult 
            { 
                LocationName = values.LocationName, 
               
            };
        }
    }
}
