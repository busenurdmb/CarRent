using CarRent.Features.CQRS.Commands.BrandCommands;
using CarRent.Features.CQRS.Handlers.BrandHandlers;
using CarRent.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        public BrandController(GetBrandQueryHandler getBrandQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        public IActionResult BrandList()
        {
            var values = _getBrandQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandCommand command)
        {
            _createBrandCommandHandler.Handle(command);
            return RedirectToAction("BrandList");
        }

        public IActionResult RemoveBrand(int id)
        {
            _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            
            var value = _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandCommand command)
        {
            _updateBrandCommandHandler.Handle(command);
            return RedirectToAction("BrandList");
        }
    }
}
