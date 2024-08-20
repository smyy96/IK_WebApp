using BESMIK.Common;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Permission;
using BESMIK.ViewModel.Spending;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personel")]
    public class SpendingController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<SpendingViewModel> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public SpendingController(HttpClient httpClient, IValidator<SpendingViewModel> validator, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = httpClient;
            _validator = validator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> SpendingList()
        {
            var user = HttpContext.User.Identity.Name;

            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

            var spendings = await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>($"https://localhost:7136/api/Spending/SpendingList");

            var list = spendings.Where(n => n.AppUserId == request.Id).ToList();

            return View(list);
        }

        public async Task<IActionResult> SpendingAdd()
        {
            return View(new SpendingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SpendingAdd(SpendingViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            ModelState.Remove("SpendingFile");


            if (!ModelState.IsValid)
            {
                ModelState.Clear();

                result.AddToModelState(ModelState);

                return View(model);
            }

            try
            {
                if (model.Picture != null)
                {
                    // Dosyanın adını model'in SpendingFile alanına atayalım
                    model.SpendingFile = model.Picture.FileName;

                    // Dosyanın kaydedileceği konumu belirleyelim
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Spending", model.SpendingFile);

                    // Kaydetmek için bir akış ortamı oluşturalım
                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    // Resmi kaydet
                    model.Picture.CopyToAsync(akisOrtami);

                    akisOrtami.Close();

                }

                model.SpendingStatus = SpendingStatus.OnayBekliyor;
                model.SpendingRequestDate = DateOnly.FromDateTime(DateTime.UtcNow);
                model.SpendingResponseDate = null;

                model.Picture = null;
                string user = HttpContext.User.Identity.Name;

                var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);
                model.AppUserId = (int) request.Id;
                // API'ye POST isteği gönder
                var response = await _httpClient.PostAsJsonAsync<SpendingViewModel>("https://localhost:7136/api/Spending/SpendingAdd", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SpendingList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Oluşturma işlemi başarısız oldu.");
                    return View(model);
                }
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "API çağrısında bir hata oluştu.");
                return View(model);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7136/api/Spending/Delete/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SpendingList");
                }
                else
                {
                    // API'den dönen hata mesajını ekleyin
                    ModelState.AddModelError(string.Empty, "Silme işlemi başarısız oldu.");
                    return RedirectToAction("SpendingList");
                }
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(string.Empty, "API çağrısında bir hata oluştu.");
                return RedirectToAction("SpendingList");
            }
        }



        [HttpGet]
        public async Task<IActionResult> SpendingEdit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7136/api/Spending/GetSpending/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["ErrorMessage"] = "harcama bulunamadı.";
                return RedirectToAction("SpendingList");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                TempData["ErrorMessage"] = "harcama talebi onay bekliyor değilse düzenlenemez.";
                return RedirectToAction("SpendingList");
            }

            response.EnsureSuccessStatusCode();

            var spending = await response.Content.ReadFromJsonAsync<SpendingViewModel>();

            ViewBag.SpendingTypes = Enum.GetValues(typeof(SpendingType))
    .Cast<SpendingType>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = e.ToString(),
        Selected = (int)e == (int)spending.SpendingType // Doğru şekilde seçiliyi ayarla
    })
    .ToList();

            ViewBag.SpendingCurrencies = Enum.GetValues(typeof(SpendingCurrency))
                .Cast<SpendingCurrency>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString(),
                    Selected = (int)e == (int)spending.SpendingCurrency // Doğru şekilde seçiliyi ayarla
                })
                .ToList();

            return View(spending);
        }


        [HttpPost]
        public async Task<IActionResult> SpendingEdit(SpendingViewModel model)
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

            try
            {
                //buradaki SpendingFile resmin adını tutan propumuz picture ise ifromfile dosyamız

                if (model.Picture != null &&
                    model.Picture.FileName != model.SpendingFile)
                {
                    //if (model.SpendingFile != null)
                    //    ResimSil(model);

                    //dosyanın adını, urun nesnesinin resim adına atayalım
                    model.SpendingFile = model.Picture.FileName;

                    //Dosyanın kaydedileceği konumu belirleyelim
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Spending", model.SpendingFile);

                    //Kaydetmek için bir akış ortamı oluşturalım
                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    //Resmi kaydet
                    model.Picture.CopyTo(akisOrtami);

                    //ortamı kapat
                    akisOrtami.Close();

                }

                else
                {
                    var spendingfilee = await _httpClient.GetFromJsonAsync<SpendingViewModel>($"https://localhost:7136/api/Spending/GetSpending/{model.Id}");
                    model.SpendingFile = spendingfilee.SpendingFile;

                }


                //string user = HttpContext.User.Identity.Name;

                //var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

                model.AppUserId = (int)request.Id;
                model.SpendingStatus = SpendingStatus.OnayBekliyor;
                model.SpendingRequestDate = DateOnly.FromDateTime(DateTime.UtcNow);
                model.SpendingResponseDate = null;
                model.Picture = null;
                



                // API'ye PUT isteği gönder
                var response = await _httpClient.PutAsJsonAsync<SpendingViewModel>($"https://localhost:7136/api/Spending/EditSpending/{model.Id}", model);


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SpendingList");
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

        //[HttpPost]
        //public async Task<IActionResult> SpendingEdit(SpendingViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var response = await _httpClient.PutAsJsonAsync($"https://localhost:7136/api/Spending/EditSpending/{model.Id}", model);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("SpendingList");
        //    }

        //    ModelState.AddModelError("", "harcama güncelleme başarısız.");
        //    return View(model);
        //}





        //public async Task<IActionResult> Edit()
        //{
        //    var userName = HttpContext.User.Identity.Name;

        //    if (string.IsNullOrEmpty(userName))
        //    {
        //        return Unauthorized();
        //    }

        //    try
        //    {
        //        var userInfo = await _httpClient.GetFromJsonAsync<SpendingViewModel>($"https://localhost:7136/api/AppUser/GetUserInfo/{userName}");

        //        ViewBag.PictureName = userInfo.SpendingFile;


        //        if (userInfo == null)
        //        {
        //            return NotFound();
        //        }


        //        return View(userInfo);
        //    }
        //    catch (HttpRequestException)
        //    {
        //        return StatusCode(500, "API çağrısında bir hata oluştu.");
        //    }
        //}





        [HttpGet]
        public IActionResult GetSpendingType()
        {
            var spendingType = Enum.GetValues(typeof(SpendingType))
                          .Cast<SpendingType>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(spendingType);
        }

        [HttpGet]
        public IActionResult GetSpendingCurrency()
        {
            var spendingCurrency = Enum.GetValues(typeof(SpendingCurrency))
                          .Cast<SpendingCurrency>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(spendingCurrency);
        }




    }
}
