namespace CarRent.Features.Mediator.Results.ReservationResults
{
    public class GetReservationByIdQueryResult
    {
        public int ReservationID { get; set; }
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
