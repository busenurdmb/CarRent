using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
