using BESMIK.Common;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
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

    public class AdvanceController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<AdvanceViewModel> _validator;

        public AdvanceController(HttpClient httpClient, IValidator<AdvanceViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> AdvancesList()
        {
            // Kullanıcının ID'sini al
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                ModelState.AddModelError("UserError", "Kullanıcı ID'si bulunamadı.");
                return View(new List<AdvanceViewModel>());
            }

            // Sadece giriş yapan kullanıcının avans taleplerini listele
            var advances = await _httpClient.GetFromJsonAsync<List<AdvanceViewModel>>($"https://localhost:7136/api/Advance/AdvancesList/{userId}");

            return View(advances);
        }



        public async Task<IActionResult> AdvanceAdd()
        {
            return View(new AdvanceViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceAdd(AdvanceViewModel model)
        {
            try
            {
                // Kullanıcının ID'sini alın
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // User.Identity'den ID'yi alın

                if (userId == null)
                {
                    ModelState.AddModelError("UserError", "Kullanıcı ID'si bulunamadı.");
                    return View(model);
                }

                // Kullanıcının bilgilerini API'den alın
                var userResponse = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Advance/GetUser/{userId}");

                if (userResponse != null)
                {
                    model.AppUserId = (int)userResponse.Id; // AppUserId'yi ayarla
                }
                else
                {
                    ModelState.AddModelError("UserError", "Kullanıcı bilgisi alınamadı.");
                    return View(model);
                }




                // avans limit kontrolü
                if (userResponse.Wage == null || userResponse.Wage == 0)
                {
                    ModelState.AddModelError("SalaryError", "Maaş bilgisi geçerli değil.");
                }
                else if (model.Amount > (userResponse.Wage * 3))
                {
                    ModelState.AddModelError("Amount", "Avans miktarı maaşınızın 3 katından fazla olamaz.");
                }







                ValidationResult result = _validator.Validate(model);

                if (!ModelState.IsValid)
                {
                    ModelState.Clear();
                    result.AddToModelState(ModelState);
                    return View(model);
                }

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/Advance/AddAdvance", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("AdvancesList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "Avans talebi oluşturulamadı. Lütfen tekrar deneyin.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                ModelState.AddModelError("GeneralInnerException", ex.InnerException?.Message);
                return View();
            }
        }


        //public async Task<IActionResult> AdvanceDelete()
        //{
        //    return View();
        //}

        //Ajax ile company section doldurma



        [HttpGet]
        public IActionResult GetAdvanceApprovalStatus()
        {
            var approvalStatus = Enum.GetValues(typeof(AdvanceApprovalStatus))
                          .Cast<AdvanceApprovalStatus>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(approvalStatus);
        }

        [HttpGet]
        public IActionResult GetAdvanceCurrency()
        {
            var advanceCurrencies = Enum.GetValues(typeof(AdvanceCurrency))
                          .Cast<AdvanceCurrency>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(advanceCurrencies);
        }
        
        [HttpGet]
        public IActionResult GetAdvanceType()
        {
            var advanceTypes = Enum.GetValues(typeof(AdvanceType))
                          .Cast<AdvanceType>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(advanceTypes);
        }
    }
}
