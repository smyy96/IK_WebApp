using BESMIK.ViewModel.Company;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class PermissionController : Controller
    {
        public class CompaniesController : Controller
        {
            private HttpClient _httpClient;
            private IValidator<CompanyViewModel> _validator;

            public CompaniesController(HttpClient httpClient, IValidator<CompanyViewModel> validator)
            {
                _httpClient = httpClient;
                _validator = validator;
            }

            [HttpGet]
            public async Task<IActionResult> PermissionList()
            {
                var companies = await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/api/Company/CompanyList");
                return View(companies);
            }


            public async Task<IActionResult> PermissonAdd()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> PermissionAdd(CompanyViewModel model)
            {
                return View();
            }



        }
    }
}
