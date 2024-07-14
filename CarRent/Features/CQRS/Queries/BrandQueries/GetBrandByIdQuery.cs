namespace CarRent.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public int BrandID { get; set; }

        public GetBrandByIdQuery(int brandID)
        {
            BrandID = brandID;
        }
    }
}
