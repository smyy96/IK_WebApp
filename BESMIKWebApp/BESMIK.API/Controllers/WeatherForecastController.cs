using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
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
        private CompanyManagerManager _companyManagerMan;
        // private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(BLLCompanyManager companyManager, CompanyManagerManager managerManagerMan )
        {
            _companyManager = companyManager;
            _companyManagerMan = managerManagerMan;
            // _logger = logger;
        }

        [HttpGet("CompanyList")]
        public IEnumerable<CompanyViewModel> CompanyGet()
        {
            return _companyManager.GetAll();
        }


        [HttpGet("CompanyManagerList")]
        public IEnumerable<CompanyManagerViewModel> CompanyManagerGet()
        {
            return _companyManagerMan.GetAll();
        }


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
