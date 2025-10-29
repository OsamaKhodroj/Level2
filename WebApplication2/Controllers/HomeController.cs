
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Controllers;


public class Country
{
       public int Id { get; set; }
    public string Name { get; set; }
}

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
        ViewBag.CountryList = GetCountries(); 
        return View();
    }


    private IEnumerable<Country> GetCountries()
    {
        return new List<Country>
        {
            new Country { Id = 1, Name = "JO" },
            new Country { Id = 2, Name = "KSA" }
        };
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
