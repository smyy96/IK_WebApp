using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
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


        //[HttpPost("SpendingAdd")]
        //public IActionResult Post([FromBody] SpendingViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var spending = new Spending
        //    {
        //        SpendingType = model.SpendingType,
        //        Sum = model.Sum,
        //        SpendingCurrency = model.SpendingCurrency,
        //        SpendingStatus = SpendingStatus.OnayBekliyor, // İlk durumda onay bekliyor
        //        SpendingRequestDate = DateOnly.FromDateTime(DateTime.UtcNow), // Talep tarihi olarak mevcut zamanı kullan
        //        SpendingResponseDate = null, // Nullable olarak null atanabilir
        //        SpendingFile = model.SpendingFile,
        //        AppUserId = model.AppUserId
        //    };

        //    _spendingService.Add(model);

        //    var createdSpending = _spendingService.Get(spending.Id);

        //    var viewModel = new SpendingViewModel
        //    {
        //        SpendingType = createdSpending.SpendingType,
        //        Sum = createdSpending.Sum,
        //        SpendingCurrency = createdSpending.SpendingCurrency,
        //        SpendingStatus = createdSpending.SpendingStatus,
        //        SpendingRequestDate = createdSpending.SpendingRequestDate,
        //        SpendingResponseDate = createdSpending.SpendingResponseDate,
        //        SpendingFile = createdSpending.SpendingFile,
        //        AppUserId = createdSpending.AppUserId
        //    };

        //    _spendingService.Add(model);
        //    return Ok(model);

        //}


    }
}
