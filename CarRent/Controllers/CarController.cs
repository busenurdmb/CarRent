
using CarRent.Features.CQRS.Handlers.BrandHandlers;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.Mediator.Commands.CarCommands;
using CarRent.Features.Mediator.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRent.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;
        private readonly GetLocationQueryHandler _queryHandler;
        private readonly GetBrandQueryHandler _querybHandler;
        public CarController(IMediator mediator, GetLocationQueryHandler queryHandler, GetBrandQueryHandler querybHandler)
        {
            _mediator = mediator;
            _queryHandler = queryHandler;
            _querybHandler = querybHandler;
        }
        [Authorize]
        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            ViewBag.Location = new SelectList(_queryHandler.Handle(), "LocationID", "LocationName");
            ViewBag.Brand = new SelectList(_querybHandler.Handle(), "BrandID", "BrandName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return RedirectToAction("CarList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            ViewBag.Location = new SelectList(_queryHandler.Handle(), "LocationID", "LocationName");
            ViewBag.Brand = new SelectList(_querybHandler.Handle(), "BrandID", "BrandName");
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("CarList");
        }
    }
}
