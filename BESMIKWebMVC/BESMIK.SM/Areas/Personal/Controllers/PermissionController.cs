using BESMIK.ViewModel.Permission;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class PermissionController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<PermissionViewModel> _validator;

        public PermissionController(HttpClient httpClient, IValidator<PermissionViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> PermissionList()
        {
            var companies = await _httpClient.GetFromJsonAsync<List<PermissionViewModel>>("https://localhost:7136/api/Company/CompanyList");
            return View(companies);
        }


        public async Task<IActionResult> PermissonAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PermissionAdd(PermissionViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> PermissionDelete()
        {
            return View();
        }



    }
}

