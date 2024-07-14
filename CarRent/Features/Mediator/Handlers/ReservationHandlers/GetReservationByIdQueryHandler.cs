using MediatR;
using CarRent.DAL.Context;
using CarRent.Features.Mediator.Queries.ReservationQueries;
using CarRent.Features.Mediator.Results.ReservationResults;

namespace ReservationRent.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly CarRentContext _context;

        public GetReservationByIdQueryHandler(CarRentContext context)
        {
            _context = context;
        }

        

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Reservations.FindAsync(request.ReservationID);
            return new GetReservationByIdQueryResult
            {
                CarID = value.CarID,
                PickUpLocationID = value.PickUpLocationID,
                DropOffLocationID = value.DropOffLocationID,
                DropOffDate = value.DropOffDate,
                PickUpDate = value.PickUpDate,

            };

        }
    }
}
