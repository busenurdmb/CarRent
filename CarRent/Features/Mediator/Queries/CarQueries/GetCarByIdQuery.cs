using CarRent.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.CarQueries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public int CarID { get; set; }

        public GetCarByIdQuery(int carID)
        {
            CarID = carID;
        }
    }
}
