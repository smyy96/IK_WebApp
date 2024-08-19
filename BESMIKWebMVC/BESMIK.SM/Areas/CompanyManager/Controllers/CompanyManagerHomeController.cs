using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.CompanyManager.Controllers
{
    public class CompanyManagerHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
