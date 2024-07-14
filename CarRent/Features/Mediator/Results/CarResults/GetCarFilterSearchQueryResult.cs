namespace CarRent.Features.Mediator.Results.CarResults
{
    public class GetCarFilterSearchQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string CarBrand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int Seats { get; set; }
        public int Doors { get; set; }
        public int LuggageCapacity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        //public int LocationID { get; set; }
        //public string LocationName { get; set; }

    }
}
