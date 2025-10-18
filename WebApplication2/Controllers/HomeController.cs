using System.Diagnostics;
using Domains.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var user = new UserService();

            //var userInfo1 = new AddUserRequest();
            //userInfo1.FullName = "John Doe";
            //userInfo1.EmailAddress = "oo@oo.com";
            //userInfo1.Password = "123456";
            //userInfo1.UserType = Domains.Enums.UserTypeEnum.Admin;

            var result = user.Add(new AddUserRequest()
            {
                EmailAddress = "aa@q.com",
                FullName = "Jane Smith",
                Password = "123456",
                UserType = Domains.Enums.UserTypeEnum.Admin
            });


            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
