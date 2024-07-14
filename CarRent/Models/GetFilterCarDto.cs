using CarRent.DAL.Entities;

namespace CarRent.Models
{
    public class GetFilterCarDto
    {
       public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
    }
}
