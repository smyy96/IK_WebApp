using BESMIK.SM.Models;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BESMIK.SM.Controllers
{
    //[Authorize(Roles = "Site Yoneticisi")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = "Anasayfa";
            return View();
        }     

        public IActionResult BizeUlasin()
        {
            ViewData["Title"] = "Bize Ulaþýn";
            return View();
        }     

        public IActionResult Blog()
        {
            ViewData["Title"] = "Blog";
            return View();
        }    
        
        //public IActionResult BlogSingle() ?
        //{
        //    return View();
        //}    
        
        public IActionResult Hakkimizda()
        {
            ViewData["Title"] = "Hakkýmýzda";
            return View();
        }     

        public IActionResult Hizmetlerimiz()
        {
            ViewData["Title"] = "Hizmetlerimiz";
            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
