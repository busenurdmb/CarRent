using CarRent.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarRent.Features.Mediator.Queries.CarQueries
{
    public class GetCarFilterSearchQuery:IRequest<List<GetCarQueryResult>>
    {
        public GetCarFilterSearchQuery(int pickUpLocationID, int dropOffLocationID, DateTime pickUpDate, DateTime dropOffDate)
        {
            PickUpLocationID = pickUpLocationID;
            DropOffLocationID = dropOffLocationID;
            PickUpDate = pickUpDate;
            DropOffDate = dropOffDate;
        }

        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
