using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Controllers
{
    [Authorize(Roles = "Site Yöneticisi2")]
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details() 
        {
            return View();
        }
        public IActionResult Edit() 
        {
            return View();
        }
        public IActionResult Delete() 
        {
            return View();
        }
    }
}
