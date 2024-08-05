using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Controllers
{
    public class ErrorPagesController : Controller
    {

        //hata sayfalarının olacagı kısım
        public IActionResult Index()
        {
            return View();
        }
    }
}
