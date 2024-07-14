using CarRent.Features.Mediator.Commands.ReservationCommands;
using CarRent.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("ReservationList");
        }

        public async Task<IActionResult> RemoveReservation(int id)
        {
            await _mediator.Send(new RemoveReservationCommand(id));
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var value = await _mediator.Send(new GetReservationByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("ReservationList");
        }
    }
}
