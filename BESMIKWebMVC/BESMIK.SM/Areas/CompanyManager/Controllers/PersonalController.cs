using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BESMIK.SM.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "Sirket Yoneticisi")]
    public class PersonalController : Controller
    {
        private readonly HttpClient _httpClient;
        private IValidator<AppUserViewModel> _validator;
        private static int companyId = 0;

        public PersonalController(HttpClient httpClient, IValidator<AppUserViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }


        public async Task<IActionResult> PersonalList()
        {
            var user = HttpContext.User.Identity.Name;

            var request = await _httpClient.GetFromJsonAsync<AppUserViewModel>("https://localhost:7136/api/UserInfo/GetUserInfo/" + user);

            return View(await _httpClient.GetFromJsonAsync<List<AppUserViewModel>>($"https://localhost:7136/api/PersonalAddList/PersonalList/{request.CompanyId}"));
        }




        public IActionResult PersonalAdd()
        {
            return View(new AppUserViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> PersonalAdd(AppUserViewModel model)
        {
            var user = HttpContext.User.Identity.Name;
            var userResponse = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/UserInfo/GetUserInfo/{user}");
            model.CompanyId = userResponse.CompanyId;

            try
            {
                ValidationResult result = _validator.Validate(model);

                ModelState.Remove("Photo");
                ModelState.Remove("PictureFile");

                if (!ModelState.IsValid)
                {
                    ModelState.Clear();

                    result.AddToModelState(ModelState);

                    return View(model);
                }



                if (model.Picture != null && model.Picture.FileName != model.Photo)
                {
                    model.Photo = model.Picture.FileName;
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/personal", model.Photo);



                    var akisOrtami = new FileStream(konum, FileMode.Create);

                    await model.Picture.CopyToAsync(akisOrtami);


                    using (var memory = new MemoryStream())
                    {
                        await model.Picture.CopyToAsync(memory);
                    }
                    akisOrtami.Close();
                }

                model.Picture = null;
                model.IsActive = true;

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/PersonalAddList/PersonalAdd", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PersonalList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "Personel eklenemedi. Lütfen tekrar deneyin.");
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



        [HttpGet("ValidationEmail")]
        public async Task<IActionResult> ValidationEmail(string usermail, string token, string returnUrl)
        {
            // API'den kullanıcıyı doğrulama isteği gönderin
            var apiUrl = $"https://localhost:7136/api/PersonalAddList/ValidationEmail?usermail={usermail}&token={token}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return Redirect(returnUrl);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("ApiError", errorMessage);
                return View("Error");
            }
        }





        //Ajax ile departman section doldurma
        [HttpGet]
        public IActionResult GetDepartments()
        {
            //Departman adlarını selectte eklemek için 
            var departments = Enum.GetValues(typeof(Department))
                          .Cast<Department>()
                          .Select(d => new { Value = ((int)d).ToString(), Text = d.ToString() })
                          .ToList();

            return Json(departments);
        }
    }
}
