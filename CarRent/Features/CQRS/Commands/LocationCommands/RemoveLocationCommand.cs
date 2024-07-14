namespace CarRent.Features.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand
    {
        public int LocationID { get; set; }

        public RemoveLocationCommand(int locationID)
        {
            LocationID = locationID;
        }
    }
}
