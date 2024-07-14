using CarRent.DAL.Context;
using CarRent.Features.CQRS.Handlers.LocationHandlers;
using CarRent.Features.Mediator.Handlers.CarHandlers;
using CarRent.Features.Mediator.Queries.CarQueries;
using CarRent.Features.Mediator.Results.CarResults;
using CarRent.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly CarRentContext _context;
        private readonly IMediator _mediator;
        private readonly GetLocationQueryHandler _queryHandler;
        public DefaultController(CarRentContext context, GetLocationQueryHandler queryHandler, IMediator mediator)
        {
            _context = context;
            _queryHandler = queryHandler;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in _context.Locations.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.LocationName,
                                               Value = x.LocationID.ToString()
                                           }).ToList();
            ViewBag.PickUpLocation = values;
            //Bu kod bloğu, _context üzerindeki Locations tablosundan tüm lokasyonları listeleyerek her bir lokasyon için bir SelectListItem nesnesi oluşturur. Her SelectListItem, LocationName özelliğini Text olarak ve LocationID özelliğini stringe çevirerek Value olarak ayarlar. Bu nesneler daha sonra ViewBag.PickUpLocation üzerinde List<SelectListItem> olarak saklanır.

            ViewBag.DropOffLocation = new SelectList(_queryHandler.Handle(), "LocationID", "LocationName");
            //Bu kod bloğu ise _queryHandler.Handle() metodunu kullanarak bir sorgu işlemi gerçekleştirir ve bu sorgudan dönen sonuçları SelectList nesnesi olarak oluşturur. Bu SelectList nesnesi, _queryHandler.Handle() metodunun dönüş değerindeki her bir öğe için LocationId özelliğini Value olarak ve LocationTitle özelliğini Text olarak ayarlar. Sonuç olarak bu SelectList nesnesi ViewBag.droplocation üzerinde saklanır.
            return View();
        }
        [HttpPost]
        public IActionResult Index(GetFilterCarDto getFilterCarDto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("RentCar", getFilterCarDto);
            }
            else
            {
                ViewBag.takelocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
                ViewBag.droplocation = new SelectList(_queryHandler.Handle(), "LocationId", "LocationTitle");
                ModelState.AddModelError("", "Alanlar boş bırakılamaz.");
                return View(getFilterCarDto);
            }
        }
        public async Task<IActionResult> RentCar(GetFilterCarDto? value)
        {
            if (value.PickUpLocationID > 0)
            {
                var res = new GetCarFilterSearchQuery(value.PickUpLocationID, value.DropOffLocationID, value.PickUpDate, value.DropOffDate);
                var values = await _mediator.Send(res);
                if (values.Count() <= 0)
                {
                    ViewBag.warning = "Aradığınız kriterlerde herhangi bir araç bulunamamıştır";
                    return View(values);
                }
                else
                {
                    ViewBag.success = "Aradığınız kriterlerde araçlar listelenmiştir.";
                    return View(values);
                }
            }
            else
            {
                var values = await _mediator.Send(new GetCarQuery());
                return View(values);
            }
        }
    }
}
