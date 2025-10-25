using Domains.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult AddUser(int? id)
        {
            var userService = new UserService();
            var model = new UserUpdateMode();

            if (id.HasValue && id.Value > 0)
            {
                model.UserInfo =  userService.GetById(id.Value);
                model.IsUpdateMode = true;
            }

            model.Users = userService.GetAll(); 

            return View(model);
        }


        [HttpPost]
        public IActionResult AddUserInfo(AddUserRequest request)
        {
            request.UserType = Domains.Enums.UserTypeEnum.Customer;

            var userService = new UserService();
            var result = userService.Add(request);
            string message = string.Empty;


            switch (result)
            { 
                case Domains.Enums.OpStatusEnum.Success:
                    message = "User added sucessfully!";
                    break;
                case Domains.Enums.OpStatusEnum.Error:
                    message = "Error happnded when add new user :(";
                    break;  
                case Domains.Enums.OpStatusEnum.AlreadyExists:
                    message = "The user already exists:(";
                    break;
                default:
                    message = "Unknown Error !";
                    break;
            } 
             
            TempData["UserMessage"] = message;
           
            return Redirect("AddUser");
         }
    }
}
