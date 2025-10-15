using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ABCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
