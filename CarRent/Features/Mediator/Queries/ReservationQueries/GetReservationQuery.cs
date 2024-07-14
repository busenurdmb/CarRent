using CarRent.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
    {
    }
}
