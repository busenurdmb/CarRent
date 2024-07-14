using CarRent.DAL.Context;
using CarRent.Features.CQRS.Results.LocationResults;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler
    {
        private readonly CarRentContext _context;

        public GetLocationQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public List<GetLocationQueryResult> Handle()
        {
            var values = _context.Locations.Select(x => new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                LocationName = x.LocationName,
            });
            return values.ToList();
        }
    }
}
