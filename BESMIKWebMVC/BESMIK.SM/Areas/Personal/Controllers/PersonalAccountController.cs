using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class PersonalAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
