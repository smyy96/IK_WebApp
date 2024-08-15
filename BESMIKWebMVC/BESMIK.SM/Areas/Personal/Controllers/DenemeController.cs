using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personel")]
    public class DenemeController : Controller
    {
        private HttpClient _httpClient;

        public DenemeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.Identity.Name;

            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

            var spendings = await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>($"https://localhost:7136/api/Spending/SpendingList");

            var list = spendings.Where(n => n.AppUserId == request.Id).ToList();

            return View(list);
        }

        public async Task<IActionResult> SpendingList()
        {
            var user = HttpContext.User.Identity.Name;

            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

            var spendings = await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>($"https://localhost:7136/api/Spending/SpendingList");

            var list = spendings.Where(n => n.AppUserId == request.Id).ToList();

            return View(list);
        }
    }
}
