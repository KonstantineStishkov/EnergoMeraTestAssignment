using Microsoft.AspNetCore.Mvc;
using RestCountries.Models;
using RestCountries.Stoarge;
using System.Diagnostics;

namespace RestCountries.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CountriesStorage _countriesStorage;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _countriesStorage = new CountriesStorage();
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCountries(int offset = 0, int limit = 10)
        {
            return Json(_countriesStorage.GetCountries(offset, limit).Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}