namespace CarRent.Features.Mediator.Results.ReservationResults
{
    public class GetReservationQueryResult
    {
        public int ReservationID { get; set; }
        public int CarID { get; set; }
        public string Carname { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string ImageUrl { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
