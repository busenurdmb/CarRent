using CarRent.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationByIdQuery : IRequest<GetReservationByIdQueryResult>
    {
        public int ReservationID { get; set; }

        public GetReservationByIdQuery(int reservationID)
        {
            ReservationID = reservationID;
        }
    }
}
