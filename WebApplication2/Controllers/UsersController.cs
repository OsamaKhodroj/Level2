using Domains.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddUserInfo(AddUserRequest request)
        {
            request.UserType = Domains.Enums.UserTypeEnum.Customer;

            var userService = new UserService();
            var result = userService.Add(request);


            return View("AddUser");
         }
    }
}
