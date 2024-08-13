using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class PersonalHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
