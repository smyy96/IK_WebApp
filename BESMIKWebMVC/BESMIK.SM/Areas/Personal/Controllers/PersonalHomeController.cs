using BESMIK.ViewModel.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personel")]
    public class PersonalHomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonalHomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
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

                ViewBag.PictureName = userInfo.Photo;

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

        // guncelleme
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

                if (model.Picture != null && model.Picture.FileName != model.Photo)
                {


                    model.Photo = model.Picture.FileName;

                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/personal", model.Photo);

                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    model.Picture.CopyTo(akisOrtami);

                    akisOrtami.Close();


                }
                model.Picture = null;
                string user = HttpContext.User.Identity.Name;

                var response = await _httpClient.PutAsJsonAsync<AppUserViewModel>($"https://localhost:7136/api/AppUser/Guncelle/{user}", model);


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Summary");
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
