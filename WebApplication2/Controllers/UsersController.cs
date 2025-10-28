using Domains.Dtos.User;
using Domains.Enums;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet] 
        [Route("add-user")]
        public async Task<IActionResult> AddUserInfoData(int? id)
        {
            var userService = new UserService();
            var model = new UserUpdateMode();

            if (id.HasValue && id.Value > 0)
            {
                model.UserInfo = userService.GetById(id.Value);
                model.IsUpdateMode = true;
            }
 
            model.Users = userService.GetAll();

            return View(model);
        }


        [HttpPost]
        public IActionResult SaveUserInfo(AddUserRequest request)
        {
            request.UserType = UserTypeEnum.Customer;

            var userService = new UserService();

            var result = OpStatusEnum.None;

            if (request.Id > 0)
            {
                var updateInfo = new UpdateUserRequest
                {
                    Id = request.Id,
                    FullName = request.FullName,
                    EmailAddress = request.EmailAddress
                };
                result = userService.Update(updateInfo);
            }
            else
            {
                result = userService.Add(request);
            }

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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userService = new UserService();
            var result = userService.Delete(id);

            return Redirect("/users/AddUser");
        }
    }
}
