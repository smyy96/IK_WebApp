using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Net.Http;
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
            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user);
            var companyId = request.CompanyId;

            var spendingManagemenList=await _httpClient.GetFromJsonAsync<IEnumerable<SpendingViewModel>>("https://localhost:7136/api/SpendingManagement/SpendingListForManager/" + companyId);
            return View(spendingManagemenList);
        }


        [HttpGet("/Spending/Details/{id}")]
        public async Task<IActionResult> SpendingManagementDetails(int id)
        {
            var response = await _httpClient.GetAsync("https://localhost:7136/api/SpendingManagement/"+ id);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }


            var responseData = await response.Content.ReadAsStringAsync();
            var spending = JsonConvert.DeserializeObject<SpendingViewModel>(responseData);





            var appUserId = spending.AppUserId;
            var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Spending/GetUser/{appUserId}");
            spending.AppUser = userInfo;


            if (spending == null || spending.AppUser == null)
            {
                return NotFound(); 
            }

           

            return View(spending);
        }

        [HttpPost("/Spending/Update")]
        public async Task<IActionResult> SpendingManagementUpdate(SpendingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("SpendingManagementDetails", viewModel); // Hata durumunda tekrar görüntüle
            }

            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

            var spendingToUpdate = new
            {
                viewModel.Id,
                viewModel.SpendingStatus,
                SpendingResponseDate = currentDate
            };

            var content = new StringContent(JsonConvert.SerializeObject(spendingToUpdate), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7136/api/SpendingManagement/{viewModel.Id}/update", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SpendingManagementDetails", new { id = viewModel.Id });
            }

            ModelState.AddModelError("", "A problem occurred while updating the spending.");
            return View("SpendingManagementDetails", viewModel);

        }
    }
}
