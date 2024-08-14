using BESMIK.ViewModel.Advance;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvanceController : Controller
    {
        //private readonly AdvanceManager _advanceManager; //Advance BLL'den gelecek, isimler muhtemelen farklı olacak

        //public AdvanceController(AdvanceManager advanceManager) 
        //{
        //    _advanceManager = advanceManager;
        //}

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Talebi ekleme

        [HttpPost("AddAdvance")]
        public IActionResult Post([FromBody] AdvanceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _advanceManager.Add(model);
            return Ok(model);
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Taleplerini Listeleme
        [HttpGet("AdvancesList")]
        public ActionResult<IEnumerable<AdvanceViewModel>> AdvanceGet()
        {
            return Ok(_advanceManager.GetAll());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
