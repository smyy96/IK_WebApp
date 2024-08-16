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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                ModelState.AddModelError("UserError", "Kullanıcı ID'si bulunamadı.");
                return View(new List<AdvanceViewModel>());
            }

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
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

                if (userId == null)
                {
                    ModelState.AddModelError("UserError", "Kullanıcı ID'si bulunamadı.");
                    return View(model);
                }

                var userResponse = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Advance/GetUser/{userId}");

                if (userResponse != null)
                {
                    model.AppUserId = (int)userResponse.Id; 
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
                    ViewBag.Avans = "Avans miktarı maaşınızın 3 katından fazla olamaz.";
                }







                ValidationResult result = _validator.Validate(model);

                if (!result.IsValid)
                {
                    ModelState.Clear();
                    result.AddToModelState(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                //if (!ModelState.IsValid)
                //{
                //    ModelState.Clear();
                //    result.AddToModelState(ModelState);
                //    return View(model);
                //}

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


        [HttpPost]
        public async Task<IActionResult> DeleteAdvance(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7136/api/Advance/DeleteAdvance/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("AdvancesList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "Avans silinemedi. Lütfen tekrar deneyin.");
                    return RedirectToAction("AdvancesList");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                return RedirectToAction("AdvancesList");
            }
        }



        [HttpGet]
        public async Task<IActionResult> AdvanceEdit(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7136/api/Advance/GetAdvance/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["ErrorMessage"] = "Avans bulunamadı.";
                return RedirectToAction("AdvancesList");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                TempData["ErrorMessage"] = "Avans talebi onay bekliyor değilse düzenlenemez.";
                return RedirectToAction("AdvancesList");
            }

            response.EnsureSuccessStatusCode();

            var advance = await response.Content.ReadFromJsonAsync<AdvanceViewModel>();

            return View(advance);
        }


        [HttpPost]
        public async Task<IActionResult> AdvanceEdit(AdvanceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7136/api/Advance/EditAdvance/{model.Id}", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AdvancesList");
            }

            ModelState.AddModelError("", "Avans güncelleme başarısız.");
            return View(model);
        }





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
