using BESMIK.Common;
using BESMIK.ViewModel.Advance;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Areas.Personal.Controllers
{
    [Area("Personal")]
    [Authorize(Roles = "Personel")] // Bu ikisi doğru mu yazıldı emin değilim. 

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
            var advances = await _httpClient.GetFromJsonAsync<List<AdvanceViewModel>>("https://localhost:7136/api/Advance/AdvancesList");
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
