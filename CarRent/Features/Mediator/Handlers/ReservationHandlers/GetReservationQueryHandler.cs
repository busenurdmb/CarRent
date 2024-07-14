
using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.ReservationQueries;
using CarRent.Features.Mediator.Results.ReservationResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ReservationRent.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly CarRentContext _context;

        public GetReservationQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reservations.Include(x => x.Car).Select(x => new GetReservationQueryResult
            {
                CarID = x.CarID,
                Carname = x.Car.Brand.BrandName + "" + x.Car.Model,
                PickUpLocation = x.PickUpLocation.LocationName,
                DropOffLocation = x.DropOffLocation.LocationName,
                PickUpLocationID = x.PickUpLocationID,
                DropOffLocationID = x.DropOffLocationID,
                DropOffDate = x.DropOffDate,
                PickUpDate = x.PickUpDate,
                ImageUrl=x.Car.ImageUrl,
            }).ToListAsync();

        }
    }
}
