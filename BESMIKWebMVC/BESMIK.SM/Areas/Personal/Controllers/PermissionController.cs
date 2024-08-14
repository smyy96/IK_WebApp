using BESMIK.Common;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.Permission;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    //[Authorize(Roles ="Personel")]
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
            var user = HttpContext.User.Identity.Name;

            var permissions = await _httpClient.GetFromJsonAsync<List<PermissionViewModel>>("https://localhost:7136/api/Permission/PermissionList/"+user);

            return View(permissions);
        }


        public async Task<IActionResult> PermissonAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PermissionAdd(PermissionViewModel model)
        {

            try
            {
                ValidationResult result = _validator.Validate(model);


                if (!ModelState.IsValid)
                {
                    ModelState.Clear();

                    model.PermissionStatus = PermissionStatus.OnayBekliyor;
                    result.AddToModelState(ModelState);

                    return View(model);
                }

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/Permission/PermissionAdd", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PermissionList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "İzin eklenemedi. Lütfen tekrar deneyin.");
                    return View(model);

                }

            }


            catch (Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                ModelState.AddModelError("GeneralInnerException", ex.InnerException?.Message);
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionType()
        {
            var types = Enum.GetValues(typeof(PermissionType))
                          .Cast<PermissionType>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(types);
        }


        public async Task<IActionResult> PermissionDelete()
        {
            return View();
        }



    }
}

