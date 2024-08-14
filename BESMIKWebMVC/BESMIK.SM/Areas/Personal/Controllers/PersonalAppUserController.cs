using BESMIK.ViewModel.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    public class PersonalAppUserController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonalAppUserController(HttpClient httpClient)
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

        // Kullanıcı bilgilerini güncelleme
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //buradaki photo resmin adını tutan propumuz picture ise ifromfile dosyamız

                if (model.Picture != null &&
                    model.Picture.FileName != model.Photo)
                {
                    //if (model.Photo != null)
                    //    ResimSil(model);

                    //dosyanın adını, urun nesnesinin resim adına atayalım
                    model.Photo = model.Picture.FileName;

                    //Dosyanın kaydedileceği konumu belirleyelim
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/appUser", model.Photo);

                    //Kaydetmek için bir akış ortamı oluşturalım
                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    //Resmi kaydet
                    model.Picture.CopyTo(akisOrtami);

                    //ortamı kapat
                    akisOrtami.Close();


                }
                model.Picture = null;
                string user = HttpContext.User.Identity.Name;
                // API'ye PUT isteği gönder
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


        //public void ResimSil(AppUserViewModel model)
        //{
        //    //bu metod, kendisine parametre olarak gönderilen urunun resmini kullanan başka 
        //    //ürün yoksa o resmi klasörden silecek

        //    var resmiKullananBaskaVarMi = _db.Menus.Any(u => u.PictureName == menu.PictureName &&
        //    u.Id != menu.Id);
        //    if (!resmiKullananBaskaVarMi) //başka yoksa sil
        //    {
        //        //resmi bul
        //        string silinecekResim = Path.Combine(Directory.GetCurrentDirectory(),
        //            "wwwroot/Images", menu.PictureName);

        //        //o resmi sil.
        //        System.IO.File.Delete(silinecekResim);
        //    }
        //}




    }
}
