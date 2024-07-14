using CarRent.DAL.Context;
using CarRent.Features.CQRS.Commands.BrandCommands;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly CarRentContext _context;

        public RemoveBrandCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(RemoveBrandCommand command)
        {
            var value = _context.Brands.Find(command.BrandID);
            _context.Brands.Remove(value);
            _context.SaveChanges();
        }
    }
}
