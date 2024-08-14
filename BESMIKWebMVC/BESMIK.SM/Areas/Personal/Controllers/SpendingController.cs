using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Spending;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Authorize(Roles = "Personal")]
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
            return View(await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>("https://localhost:7136/api/CompanyManager/CompanyManagerList"));
        }


        public async Task<IActionResult> SpendingAdd()
        {
            return View(new SpendingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SpendingAdd(SpendingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            




            return View(model);

        }

        public async Task<IActionResult> SpendingDelete()
        {
            return View();
        }


    }
}
