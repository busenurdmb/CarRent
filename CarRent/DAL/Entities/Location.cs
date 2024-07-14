namespace CarRent.DAL.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        //public string Address { get; set; }
        public List<Reservation> PickUpLocation { get; set; }
        public List<Reservation> DropOffLocation { get; set; }
        
    }
}
