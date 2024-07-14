namespace CarRent.Features.CQRS.Commands.LocationCommands
{
    public class UpdateLocationCommand
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        //public string Address { get; set; }
    }
}
