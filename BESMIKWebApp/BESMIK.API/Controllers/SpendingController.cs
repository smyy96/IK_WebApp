using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingController : Controller
    {
        private readonly SpendingManager _spendingService;
                private readonly UserManager<AppUser> _userManager;

        //private readonly BLL.Managers.Concrete.Spending _spending; //buna gerek yok sc

        public SpendingController(SpendingManager spendingService)

        {
            _spendingService = spendingService;
        }


        [HttpGet("SpendingList")]
        public ActionResult<IEnumerable<SpendingViewModel>> GetList()
        {
            var spendings = _spendingService.GetAll();
            return Ok(spendings);

        }

        [HttpPost("SpendingAdd")]
        public IActionResult Post([FromBody] SpendingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _spendingService.Add(model);
            return Ok(model);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var spending = _spendingService.Get(id);
            if (spending == null)
            {
                return NotFound();
            }

            return Ok(spending);
        }

    }
}
