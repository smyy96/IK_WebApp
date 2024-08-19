using BESMIK.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BESMIK.SM.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            //https://localhost:7136/api/Account/SignIn  https://localhost:7136/api/Account/Logout
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7136/"); //Api url

            SignInViewModel signInViewModel = new SignInViewModel();
            signInViewModel.Email = email;
            signInViewModel.Password = password;


            string modelJson = JsonSerializer.Serialize(signInViewModel);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync("/api/Account/SignIn", content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {

                SignInResponseViewModel responseViewModel = responseMessage.Content.ReadFromJsonAsync<SignInResponseViewModel>().Result;

                List<Claim> claims = new List<Claim>();

                foreach (UserClaimViewModel item in responseViewModel.Claims)
                {
                    Claim claim = new Claim(item.Type, item.Value);
                    claims.Add(claim);
                }


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("BasicAuth", responseViewModel.BasicAuth);

                if (responseViewModel.Role == "Personel")
                {
                    return RedirectToAction("Index", "PersonalHome", new { area = "Personal" });

                }

                else if (responseViewModel.Role == "Site Yoneticisi")
                {
                    return RedirectToAction("Summary", "AppUser");
                }

                else if (responseViewModel.Role == "Sirket Yoneticisi")
                {
                    return RedirectToAction("Index", "CompanyManagerHome", new { area = "CompanyManager" });
                }

            }

            TempData["ErrorMessage"] = "Kullanıcı bulunamadı veya geçersiz şifre!";
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            HttpClient _httpClient = new HttpClient();

            await HttpContext.SignOutAsync(); //mvc cıkıs

            //apiden logout
            try
            {
                var response = await _httpClient.PostAsync("https://localhost:7136/api/Account/Logout", null);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = "Logout başarısız.";
                    return RedirectToAction("Index", "ErrorPages");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Bir hatalar var :(";
                return RedirectToAction("Index", "ErrorPages");
            }

            // login sayfasına yönlendirme
            return RedirectToAction("Login", "Account");

        }


        ////Erişim hatası
        public IActionResult AccessDenied()
        {
            var user = HttpContext.User;

            return View();
        }
    }
}
