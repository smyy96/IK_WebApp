using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Permission;
using BESMIK.ViewModel.Spending;
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
    [Authorize(Roles = "Personel")]
    public class PermissionController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<PermissionViewModel> _validator;



        public PermissionController(HttpClient httpClient, IValidator<PermissionViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            string user = HttpContext.User.Identity.Name;
            return View(await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user));
        }

        public async Task<IActionResult> PermissionList()
        {
           
                var user = HttpContext.User.Identity.Name;

                var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

                var permission = await _httpClient.GetFromJsonAsync<List<PermissionViewModel>>($"https://localhost:7136/api/Permission/PermissionList");

                var list = permission.Where(n => n.AppUserId == request.Id).ToList();

                return View(list);
            
        }

        public async Task<IActionResult> PermissionAdd()
        {
            return View(new PermissionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> PermissionAdd(PermissionViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!ModelState.IsValid)
            {
                ModelState.Clear();

                result.AddToModelState(ModelState);

                return View(model);
            }

            try
            {
                var user = HttpContext.User.Identity.Name;
                var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/AppUser/GetUserInfo/{user}");
                if (request == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bilgileri alınamadı.");
                    return View(model);
                }

                model.AppUserId = (int)request.Id;
                model.PermissionStatus = PermissionStatus.OnayBekliyor;

                // Tarih hesaplaması
                DateOnly start = model.PermissionStartDate;
                DateOnly end = model.PermissionEndDate;
                int offDaysNumbers = end.DayNumber - start.DayNumber; // DateOnly kullanarak gün farkını hesaplayın.
                model.OffDaysNumbers = offDaysNumbers.ToString();
                model.PermissionResponseDate = null;
                model.PermissionRequestDate = DateOnly.FromDateTime(DateTime.UtcNow);

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/Permission/PermissionAdd", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PermissionList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Oluşturma işlemi başarısız oldu.");
                    return View(model);
                }
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "API çağrısında bir hata oluştu.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult GetPermissionType()
        {
            var permissionTypes = Enum.GetValues(typeof(PermissionType))
                .Cast<PermissionType>()
                .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                .ToList();

            return Json(permissionTypes);
        }


    }
}

