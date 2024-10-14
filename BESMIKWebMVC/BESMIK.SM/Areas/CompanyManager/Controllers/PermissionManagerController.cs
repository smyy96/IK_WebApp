using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.Permission;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "Sirket Yoneticisi")]
    public class PermissionManagerController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<PermissionViewModel> _validator;

        public PermissionManagerController(HttpClient httpClient, IValidator<PermissionViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            string user = HttpContext.User.Identity.Name;
            var appUser = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user);
            var companyId = appUser.CompanyId;

            return View(await _httpClient.GetFromJsonAsync<PermissionViewModel>("https://localhost:7136/api/Permission/PermissionListByCompanyId/" + companyId));
        }
        public async Task<IActionResult> PermissionListByCompanyId()
        {
            var user = HttpContext.User.Identity.Name;
            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);
            var companyId = request.CompanyId;
            var permissionList = await _httpClient.GetFromJsonAsync<IEnumerable<PermissionViewModel>>("https://localhost:7136/api/Permission/PermissionListByCompanyId/" + companyId);
            return View(permissionList);
        }
        public async Task<IActionResult> Details(int id)//permissionid
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7136/api/Permission/GetPermission/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["ErrorMessage"] = "İzin bulunamadı.";
                    return RedirectToAction("PermissionListByCompanyId");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    TempData["ErrorMessage"] = "İzin talebi onay bekliyor değilse düzenlenemez.";
                    return RedirectToAction("PermissionListByCompanyId");
                }
                response.EnsureSuccessStatusCode();


                var permission = await response.Content.ReadFromJsonAsync<PermissionViewModel>();
                var appUserId = permission.AppUserId;
                var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Advance/GetUser/{appUserId}");
                
                permission.AppUser = userInfo;
               
                return View(permission);
            }
            catch (HttpRequestException ex)
            {

                TempData["ErrorMessage"] = "API çağrısında bir hata oluştu. " + ex.Message;
                return RedirectToAction("PermissionListByCompanyId");
            }

        }
        [HttpGet]
        public async Task<IActionResult> PermissionApprove(int id)//permissionidsi
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7136/api/Permission/GetPermission/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["ErrorMessage"] = "İzin bulunamadı.";
                    return RedirectToAction("PermissionListByCompanyId");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    TempData["ErrorMessage"] = "İzin talebi onay bekliyor değilse düzenlenemez.";
                    return RedirectToAction("PermissionListByCompanyId");
                }
                response.EnsureSuccessStatusCode();


                var permission = await response.Content.ReadFromJsonAsync<PermissionViewModel>();

                return View(permission);
            }
            catch (HttpRequestException ex)
            {

                TempData["ErrorMessage"] = "API çağrısında bir hata oluştu. " + ex.Message;
                return RedirectToAction("PermissionListByCompanyId");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PermissionApprove(PermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var permissionID = model.Id;
            var result = await _httpClient.GetAsync($"https://localhost:7136/api/Permission/GetPermission/{permissionID}");
            var permission = await result.Content.ReadFromJsonAsync<PermissionViewModel>();
            model.OffDaysNumbers = permission.OffDaysNumbers;
            model.AppUser = permission.AppUser;
            model.AppUserId=permission.AppUserId;
            model.PermissionType= permission.PermissionType;
            model.PermissionRequestDate = permission.PermissionRequestDate;
            model.PermissionStartDate= permission.PermissionStartDate;
            model.PermissionEndDate= permission.PermissionEndDate;
            model.PermissionResponseDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7136/api/Permission/PermissionEdit/{model.Id}", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("PermissionListByCompanyId");
            }

            ModelState.AddModelError("", "İzin güncelleme başarısız.");
            return View(model);

        }

        [HttpGet]
        public IActionResult GetPermissionStatus()
        {
            var permissionStatus = Enum.GetValues(typeof(PermissionStatus))
                .Cast<PermissionStatus>()
                .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                .ToList();

            return Json(permissionStatus);
        }
    }
}
