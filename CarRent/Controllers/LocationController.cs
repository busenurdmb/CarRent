using CarRent.Features.CQRS.Commands.LocationCommands;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.CQRS.Queries.LocationQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {

        private readonly GetLocationQueryHandler _getLocationQueryHandler;
        private readonly CreateLocationCommandHandler _createLocationCommandHandler;
        private readonly RemoveLocationCommandHandler _removeLocationCommandHandler;
        private readonly UpdateLocationCommandHandler _updateLocationCommandHandler;
        private readonly GetLocationByIdQueryHandler _getLocationByIdQueryHandler;
        public LocationController(GetLocationQueryHandler getLocationQueryHandler, CreateLocationCommandHandler createLocationCommandHandler, RemoveLocationCommandHandler removeLocationCommandHandler, UpdateLocationCommandHandler updateLocationCommandHandler, GetLocationByIdQueryHandler getLocationByIdQueryHandler)
        {
            _getLocationQueryHandler = getLocationQueryHandler;
            _createLocationCommandHandler = createLocationCommandHandler;
            _removeLocationCommandHandler = removeLocationCommandHandler;
            _updateLocationCommandHandler = updateLocationCommandHandler;
            _getLocationByIdQueryHandler = getLocationByIdQueryHandler;
        }

        public IActionResult LocationList()
        {
            var values = _getLocationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLocation(CreateLocationCommand command)
        {
            _createLocationCommandHandler.Handle(command);
            return RedirectToAction("LocationList");
        }

        public IActionResult RemoveLocation(int id)
        {
            _removeLocationCommandHandler.Handle(new RemoveLocationCommand(id));
            return RedirectToAction("LocationList");
        }

        [HttpGet]
        public IActionResult UpdateLocation(int id)
        {

            var value = _getLocationByIdQueryHandler.Handle(new GetLocationByIdQuery(id));
            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateLocation(UpdateLocationCommand command)
        {
            _updateLocationCommandHandler.Handle(command);
            return RedirectToAction("LocationList");
        }
    }
}
