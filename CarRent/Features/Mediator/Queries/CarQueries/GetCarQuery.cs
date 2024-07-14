using CarRent.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.CarQueries
{
    public class GetCarQuery : IRequest<List<GetCarQueryResult>>
    {
    }
}
