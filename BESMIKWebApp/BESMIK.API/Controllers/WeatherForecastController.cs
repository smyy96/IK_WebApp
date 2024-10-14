using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly BLLCompanyManager _companyManager;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(BLLCompanyManager companyManager)
        {
            _companyManager = companyManager;
        
            //_logger = logger;
        }

        [HttpGet("CompanyList")]
        public IEnumerable<CompanyViewModel> CompanyGet()
        {
            return _companyManager.GetAll();
        }


        //[HttpGet("CompanyManagerList")]
        //public IEnumerable<CompanyManagerViewModel> CompanyManagerGet()
        //{
        //    return _companyManagerMan.GetAll();
        //}

        //�irketi ID'sine g�re getirme
        [HttpGet("Company/{id}")]
        public IActionResult GetCompany(int id) 
        {
            return Ok(_companyManager.Get(id));
        }

        //�irket y�neticisini ID'sine g�re getirme

        //[HttpGet("CompanyManager/{id}")]
        //public IActionResult GetManager(int id)
        //{
        //    return Ok(_companyManagerMan.Get(id));

        //}


        [HttpDelete("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var existingCompany = _companyManager.Get(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            _companyManager.Delete(existingCompany);
            return NoContent();
        }

        //[HttpPost("AddCompany")]
        //public IActionResult AddCompany(CompanyViewModel companyViewModel)
        //{
        //    _companyManager.Add(companyViewModel);
        //    return CreatedAtAction(nameof(GetCompanyById), new { id = companyViewModel.Id }, companyViewModel);
        //}

        

        ////�irket y�neticisi ekleme
        //[HttpPost("AddCompanyManager")]
        //public ActionResult<CompanyManagerViewModel> AddCompanyManager(CompanyManagerViewModel companyManagerViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _companyManagerMan.Add(companyManagerViewModel);
        //    return CreatedAtAction(nameof(GetCompanyManagerById), new { id = companyManagerViewModel.Id }, companyManagerViewModel);
        //}

        //�irket y�neticisi silme

        //[HttpDelete("DeleteCompanyManager")]
        //public ActionResult DeleteCompanyManager(int id)
        //{
        //    var companyManager = _companyManagerMan.Get(id);
        //    if (companyManager == null)
        //    {
        //        return NotFound();
        //    }
        //    _companyManagerMan.Delete(id);
        //    return NoContent();

        //}

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
