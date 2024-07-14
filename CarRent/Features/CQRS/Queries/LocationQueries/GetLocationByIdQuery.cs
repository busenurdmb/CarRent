namespace CarRent.Features.CQRS.Queries.LocationQueries
{
    public class GetLocationByIdQuery
    {
        public int LocationID { get; set; }

        public GetLocationByIdQuery(int locationID)
        {
            LocationID = locationID;
        }
    }
}
