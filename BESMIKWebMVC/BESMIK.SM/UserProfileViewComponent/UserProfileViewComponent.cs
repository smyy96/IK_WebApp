using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BESMIK.SM.UserProfileViewComponent
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProfileViewComponent(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string user = HttpContext.User.Identity.Name;
            var userProfile = await GetUserAsync(user);
            return View(userProfile);
        }

        private async Task<AppUserViewModel> GetUserAsync(string user)
        {



            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

            return request;


        }

    }
}
