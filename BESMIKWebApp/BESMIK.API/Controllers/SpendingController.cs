using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingController : Controller
    {
        private readonly SpendingManager _spendingService;
        private readonly BLL.Managers.Concrete.Spending _spending;

        public SpendingController(SpendingManager spendingService, BLL.Managers.Concrete.Spending spending)
        {
            _spendingService = spendingService;
            _spending = spending;
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
