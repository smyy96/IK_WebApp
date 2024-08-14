using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Spending;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personal")]
    public class SpendingController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<SpendingViewModel> _validator;

        public SpendingController(HttpClient httpClient, IValidator<SpendingViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> SpendingList()
        {
            return View(await _httpClient.GetFromJsonAsync<List<SpendingViewModel>>("https://localhost:7136/api/CompanyManager/CompanyManagerList"));
        }


        public async Task<IActionResult> SpendingAdd()
        {
            return View(new SpendingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SpendingAdd(SpendingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                if (model.Picture != null)
                {
                    // Dosyanın adını model'in Photo alanına atayalım
                    model.SpendingFile = model.Picture.FileName;

                    // Dosyanın kaydedileceği konumu belirleyelim
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Spending", model.SpendingFile);

                    // Kaydetmek için bir akış ortamı oluşturalım
                    using (var akisOrtami = new FileStream(konum, FileMode.Create))
                    {
                        // Resmi kaydet
                        await model.Picture.CopyToAsync(akisOrtami);
                    }
                }

                // API'ye POST isteği gönder
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/AppUser/Olustur", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Summary");
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

    }
}
