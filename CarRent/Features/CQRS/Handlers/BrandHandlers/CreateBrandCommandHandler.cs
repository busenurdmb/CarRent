using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using CarRent.Features.CQRS.Commands.BrandCommands;

namespace CarRent.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly CarRentContext _context;

        public CreateBrandCommandHandler(CarRentContext context)
        {
            _context = context;
        }
        public void Handle(CreateBrandCommand command)
        {
            _context.Brands.Add(new Brand
            {
                BrandName = command.BrandName
            });
            _context.SaveChanges();
        }

    }
}
