using CarRent.DAL.Context;
using CarRent.Features.CQRS.Queries.BrandQueries;
using CarRent.Features.CQRS.Results.BrandResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly CarRentContext _context;

        public GetBrandByIdQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public GetBrandByIdQueryResult Handle(GetBrandByIdQuery query)
        {
            var value = _context.Brands.Find(query.BrandID);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID, 
                BrandName = value.BrandName 
            };
        }
    }
}
