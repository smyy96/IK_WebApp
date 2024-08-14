using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class AdvanceController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<AdvanceViewModel> _validator;

        public AdvanceController(HttpClient httpClient, IValidator<AdvanceViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> AdvanceList()
        {
            var companies = await _httpClient.GetFromJsonAsync<List<AdvanceViewModel>>("https://localhost:7136/api/Company/CompanyList");
            return View(companies);
        }


        public async Task<IActionResult> AdvanceAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceAdd(AdvanceViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> AdvanceDelete()
        {
            return View();
        }
    }
}
