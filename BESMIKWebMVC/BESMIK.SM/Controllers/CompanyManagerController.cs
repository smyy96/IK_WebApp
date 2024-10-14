using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BESMIK.SM.Controllers
{
    [Authorize(Roles = "Site Yoneticisi")]
    public class CompanyManagerController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<AppUserViewModel> _validator;

        public CompanyManagerController(HttpClient httpClient, IValidator<AppUserViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }


        public async Task<IActionResult> CompanyManagerList()
        {
            return View(await _httpClient.GetFromJsonAsync<List<AppUserViewModel>>("https://localhost:7136/api/CompanyManager/CompanyManagerList"));
        }


        public async Task<IActionResult> CompanyManagerAdd()
        {
            return View(new AppUserViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> CompanyManagerAdd(AppUserViewModel model)
        {

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
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/companyManager", model.Photo);



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

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/CompanyManager/CompanyManagerAdd", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CompanyManagerList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "Şirket Yöneticisi eklenemedi. Lütfen tekrar deneyin.");
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




        private async Task<byte[]> GetFileBytesAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }





        //Ajax ile company section doldurma
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            //Şirket adlarını selectte eklemek için
            var companies = await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/api/CompanyManager/CompanyNameList");
            return Json(companies);
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