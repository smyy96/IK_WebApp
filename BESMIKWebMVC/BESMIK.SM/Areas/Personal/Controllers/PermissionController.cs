using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Permission;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles ="Personel")]
    public class PermissionController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<PermissionViewModel> _validator;



        public PermissionController(HttpClient httpClient, IValidator<PermissionViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        public async Task<IActionResult> PermissionList()
        {
           
            var user = HttpContext.User.Identity.Name;
            
            var permissions = await _httpClient.GetFromJsonAsync<List<PermissionViewModel>>($"https://localhost:7136/api/Permission/PermissionList?user={user}");

            return View(permissions);
        }


        public async Task<IActionResult> PermissionAdd()
        {
            return View(new PermissionViewModel());
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
                    result.AddToModelState(ModelState);
                    return View(model);

                }
                var user = HttpContext.User.Identity.Name;
                var userResponse= await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user);
                model.AppUserId = (int)userResponse.Id;
                model.PermissionStatus = PermissionStatus.OnayBekliyor;
                DateOnly start = model.PermissionStartDate;
                DateOnly end = model.PermissionEndDate;
                int offDaysNumbers = (end.DayNumber - start.DayNumber);
                string offDaysString = offDaysNumbers.ToString();
                model.OffDaysNumbers = offDaysString;
                model.PermissionResponseDate = null;

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

        [HttpGet("GetPermissionTypes")]
        public IActionResult GetPermissionTypes()
        {
            var types = Enum.GetValues(typeof(PermissionType))
                           .Cast<PermissionType>()
                           .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                           .ToList();

            return Ok(types);
        }


    }
}

