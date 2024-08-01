using BESMIK.SM.Models;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BESMIK.SM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/WeatherForecast/CompanyList"));
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
