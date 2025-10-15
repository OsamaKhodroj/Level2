using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class SystemUserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
