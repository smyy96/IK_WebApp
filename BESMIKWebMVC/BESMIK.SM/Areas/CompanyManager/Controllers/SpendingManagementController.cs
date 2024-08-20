using BESMIK.Common;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Permission;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace BESMIK.SM.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "Sirket Yoneticisi")]
    public class SpendingManagementController : Controller
    {
        private readonly HttpClient _httpClient;


        public SpendingManagementController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> SpendingManagementList()
        {
            var user = HttpContext.User.Identity.Name;
            if (user == null)
            {
                return Unauthorized();
            }

            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user);
            var companyId = request.CompanyId;

            var spendingManagemenList = await _httpClient.GetFromJsonAsync<IEnumerable<SpendingViewModel>>("https://localhost:7136/api/SpendingManagement/SpendingListForManager/" + companyId);
            return View(spendingManagemenList);
        }



        [HttpGet]
        public async Task<IActionResult> SpendingManagementDetails(int id)
        {
            var response = await _httpClient.GetAsync("https://localhost:7136/api/SpendingManagement/GetSpending/" + id);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["ErrorMessage"] = "Harcama bulunamadı.";
                return RedirectToAction("SpendingManagementList");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                TempData["ErrorMessage"] = "Harcama talebi onay bekliyor değilse düzenlenemez.";
                return RedirectToAction("SpendingManagementList");
            }

            response.EnsureSuccessStatusCode();

            var spending = await response.Content.ReadFromJsonAsync<SpendingViewModel>();
            var appUserId = spending.AppUserId;
            var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/SpendingManagement/GetUser/{appUserId}");

            spending.AppUser = userInfo;

            return View(spending);
        }


        [HttpPost]
        public async Task<IActionResult> SpendingManagementDetails(SpendingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = HttpContext.User.Identity.Name;
            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/AppUser/GetUserInfo/{user}");
            if (request == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bilgileri alınamadı.");
                return View(model);
            }

            model.AppUserId = (int)request.Id;

            var spendingID = model.Id;
            var result = await _httpClient.GetAsync($"https://localhost:7136/api/Spending/GetSpending/{spendingID}");
            var spending = await result.Content.ReadFromJsonAsync<SpendingViewModel>();

            model.AppUser = spending.AppUser;
            model.AppUserId = spending.AppUserId;
            model.SpendingType = spending.SpendingType;
            model.Sum = spending.Sum;
            model.SpendingCurrency = spending.SpendingCurrency;
            model.SpendingRequestDate = spending.SpendingRequestDate;
            model.SpendingResponseDate = DateOnly.FromDateTime(DateTime.UtcNow);
            model.SpendingFile = spending.SpendingFile;

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7136/api/SpendingManagement/{model.Id}/update", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SpendingManagementList");
            }

            ModelState.AddModelError("", "Harcama güncelleme işlemi başarısızdır");

            return View(model);

        }



        [HttpGet]
        public IActionResult GetSpendingStatus()
        {
            var spendingStatus = Enum.GetValues(typeof(SpendingStatus))
                          .Cast<SpendingStatus>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(spendingStatus);
        }


        //[HttpGet("/Spending/Details/{id}")]
        //public async Task<IActionResult> SpendingManagementDetails(int id)
        //{
        //    var response = await _httpClient.GetAsync("https://localhost:7136/api/SpendingManagement/"+ id);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return NotFound();
        //    }


        //    var responseData = await response.Content.ReadAsStringAsync();
        //    var spending = JsonConvert.DeserializeObject<SpendingViewModel>(responseData);


        //    //var appUserId = spending.AppUserId;
        //    //var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Spending/GetUser/{appUserId}");
        //    //spending.AppUser = userInfo;


        //    if (spending == null || spending.AppUser == null)
        //    {
        //        return NotFound(); 
        //    }



        //    return View(spending);
        //}

        //[HttpPost("/Spending/Update")]
        //public async Task<IActionResult> SpendingManagementUpdate(SpendingViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("SpendingManagementDetails", viewModel); // Hata durumunda tekrar görüntüle
        //    }

        //    var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

        //    var spendingToUpdate = new
        //    {
        //        viewModel.Id,
        //        viewModel.SpendingStatus,
        //        SpendingResponseDate = currentDate
        //    };

        //    var content = new StringContent(JsonConvert.SerializeObject(spendingToUpdate), Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PostAsync($"https://localhost:7136/api/SpendingManagement/{viewModel.Id}/update", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("SpendingManagementDetails", new { id = viewModel.Id });
        //    }

        //    ModelState.AddModelError("", "A problem occurred while updating the spending.");
        //    return View("SpendingManagementDetails", viewModel);

        //}
    }
}
