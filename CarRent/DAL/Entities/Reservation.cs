namespace CarRent.DAL.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CarID { get; set; }
     
        public Car Car { get; set; }
        public int PickUpLocationID { get; set; }
        public Location PickUpLocation { get; set; }
        public int DropOffLocationID { get; set; }
        public Location DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
