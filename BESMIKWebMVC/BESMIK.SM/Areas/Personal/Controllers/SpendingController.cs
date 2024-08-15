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
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personel")]
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
                    // Dosyanın adını model'in Photo alanına atayalım
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
