using CarRent.DAL.Context;
using CarRent.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CarRent.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        CarRentContext _context=new CarRentContext();
        //private readonly CarRentContext _context;

        //public LoginController(CarRentContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = _context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (values != null)
            {
                // Session işlemleri
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, values.Username),
            new Claim(ClaimTypes.Email, values.Email),
            // Diğer gerekli bilgileri buraya ekleyin
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Kalıcı olacak mı?
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Geçerlilik süresi
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties).Wait();

                return RedirectToAction("CarList", "Car");
            }
            return View();
         
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Default"); // veya başka bir sayfaya yönlendirme yapabilirsiniz.
        }
    }
}
