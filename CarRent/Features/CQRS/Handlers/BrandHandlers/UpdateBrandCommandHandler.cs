using CarRent.DAL.Context;
using CarRent.Features.CQRS.Commands.BrandCommands;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly CarRentContext _context;

        public UpdateBrandCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateBrandCommand command)
        {
            var value = _context.Brands.Find(command.BrandID);
            value.BrandName=command.BrandName;
            _context.SaveChanges();
        }
    }
}
