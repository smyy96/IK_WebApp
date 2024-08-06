using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel;
using System.Net.Http.Headers;

namespace BESMIK.SM.Controllers
{
    [Authorize(Roles = "Site Yöneticisi")]
    public class AppUserController : Controller
    {
        private readonly HttpClient _httpClient;

        public AppUserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Summary()
        {
            string user = HttpContext.User.Identity.Name;
            return View(await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user)); 
        }


        public async Task<IActionResult> Details()
        {
            string user = HttpContext.User.Identity.Name;
            return View(await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/AppUser/GetUserInfo/" + user));
        }


        public async Task<IActionResult> Edit()
        {
            var userName = HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return Unauthorized();
            }

            try
            {
                var userInfo = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/AppUser/GetUserInfo/{userName}");

                if (userInfo == null)
                {
                    return NotFound();
                }

                return View(userInfo);
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "API çağrısında bir hata oluştu.");
            }
        }

        // Kullanıcı bilgilerini güncelleme
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserViewModel model, IFormFile photo)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var content = new MultipartFormDataContent();

                // Modeli JSON olarak ekle
                var jsonModel = JsonContent.Create(model);
                content.Add(jsonModel, "userInfo");

                // Fotoğraf varsa ekle
                if (photo != null && photo.Length > 0)
                {
                    var photoStream = new MemoryStream();
                    await photo.CopyToAsync(photoStream);
                    var photoContent = new StreamContent(new MemoryStream(photoStream.ToArray()));
                    photoContent.Headers.ContentType = new MediaTypeHeaderValue(photo.ContentType);
                    content.Add(photoContent, "photo", photo.FileName);
                }

                // API'ye PUT isteği gönder
                var response = await _httpClient.PutAsync("https://localhost:7136/api/AppUser/Guncelle/", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Güncelleme işlemi başarısız oldu.");
                    return View(model);
                }
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "API çağrısında bir hata oluştu.");
                return View(model);
            }
        }


    }
}
