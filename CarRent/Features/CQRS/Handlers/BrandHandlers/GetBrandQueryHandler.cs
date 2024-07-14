using CarRent.DAL.Context;
using CarRent.Features.CQRS.Results.BrandResults;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly CarRentContext _context;

        public GetBrandQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public List<GetBrandQueryResult> Handle()
        {
            var values= _context.Brands.Select(x => new GetBrandQueryResult { BrandID = x.BrandID, BrandName = x.BrandName });
            return values.ToList();
        }
    }
}
