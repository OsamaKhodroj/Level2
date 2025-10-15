using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
    }
}
