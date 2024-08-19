using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Net.Http;

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
    }
}
