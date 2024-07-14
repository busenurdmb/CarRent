using CarRent.DAL.Context;
using CarRent.Features.CQRS.Commands.LocationCommands;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly CarRentContext _context;

        public UpdateLocationCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateLocationCommand command)
        {
            var value = _context.Locations.Find(command.LocationID);
            value.LocationName= command.LocationName;
            
            _context.SaveChanges();
        }
    }
}
