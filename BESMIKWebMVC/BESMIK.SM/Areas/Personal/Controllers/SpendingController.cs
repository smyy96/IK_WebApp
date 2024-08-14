using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class SpendingController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<SpendingViewModel> _validator;

        public SpendingController(HttpClient httpClient, IValidator<SpendingViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> SpendingList()
        {
            var companies = await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>("https://localhost:7136/api/Company/CompanyList");
            return View(companies);
        }


        public async Task<IActionResult> SpendingAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SpendingAdd(SpendingViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> SpendingDelete()
        {
            return View();
        }


    }
}
