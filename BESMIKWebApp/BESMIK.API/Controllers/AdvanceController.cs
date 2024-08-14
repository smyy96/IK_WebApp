using BESMIK.BLL.Managers.Concrete;
using BESMIK.ViewModel.Advance;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly AdvanceManager _advanceManager;

        public AdvanceController(AdvanceManager advanceManager)
        {
            _advanceManager = advanceManager;
        }

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
        
    }
}
