using BESMIK.Common;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.Permission;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Security.Claims;

namespace BESMIK.SM.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "Sirket Yoneticisi")]
    public class AdvanceManagementController : Controller
    {

        private HttpClient _httpClient;
        private IValidator<CompanyViewModel> _validator;

        public AdvanceManagementController(HttpClient httpClient, IValidator<CompanyViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7136/api/Advance/GetAdvance/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["ErrorMessage"] = "Avans bulunamadı.";
                    return RedirectToAction("AdvancesList");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    TempData["ErrorMessage"] = "Avans talebi onay bekliyor değilse düzenlenemez.";
                    return RedirectToAction("AdvancesList");
                }
                response.EnsureSuccessStatusCode();


                var advance = await response.Content.ReadFromJsonAsync<AdvanceViewModel>();
                var appUserId = advance.AppUserId;
                var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Advance/GetUser/{appUserId}");

                advance.AppUser = userInfo;

                return View(advance);
            }
            catch (HttpRequestException ex)
            {

                TempData["ErrorMessage"] = "API çağrısında bir hata oluştu. " + ex.Message;
                return RedirectToAction("AdvancesList");
            }

        }


        public async Task<IActionResult> AdvancesList()
        {
            var user = HttpContext.User.Identity.Name;
            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);
            var companyId = request.CompanyId;
            var advancesList = await _httpClient.GetFromJsonAsync<IEnumerable<AdvanceViewModel>>("https://localhost:7136/api/AdvanceManagement/AdvanceListByCompanyId/" + companyId);
            return View(advancesList);
        }

        [HttpGet]
        public async Task<IActionResult> AdvanceEdit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7136/api/Advance/GetAdvance/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["ErrorMessage"] = "Avans bulunamadı.";
                return RedirectToAction("AdvancesList");
            }

            response.EnsureSuccessStatusCode();

            var advance = await response.Content.ReadFromJsonAsync<AdvanceViewModel>();

            return View(advance);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceEdit(AdvanceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7136/api/AdvanceManagement/EditAdvance/{model.Id}", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AdvancesList");
            }

            ModelState.AddModelError("", "Avans güncelleme başarısız.");
            return View(model);
        }


        [HttpGet]
        public IActionResult GetAdvanceApprovalStatus()
        {
            var approvalStatus = Enum.GetValues(typeof(AdvanceApprovalStatus))
                          .Cast<AdvanceApprovalStatus>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(approvalStatus);
        }

    }
}