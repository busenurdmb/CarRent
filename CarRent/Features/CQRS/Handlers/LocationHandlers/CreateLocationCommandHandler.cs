using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using CarRent.Features.CQRS.Commands.LocationCommands;

namespace CarRent.Features.CQRS.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler
    {
        private readonly CarRentContext _context;

        public CreateLocationCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(CreateLocationCommand command)
        {
            _context.Add(new Location
            {
                LocationName = command.LocationName,
                

            });
            _context.SaveChanges();
        }
    }
}
