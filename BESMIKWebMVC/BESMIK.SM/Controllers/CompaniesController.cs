using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Controllers
{
    [Authorize(Roles = "Site Yöneticisi")]
    public class CompaniesController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<CompanyViewModel> _validator;

        public CompaniesController(HttpClient httpClient, IValidator<CompanyViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        public async Task<IActionResult> CompaniesList()
        {
            return View(await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/api/Company/CompanyList"));
        }


        public async Task<IActionResult> CompanyAdd()
        {
            return View(new CompanyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CompanyAdd(CompanyViewModel model)
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



                if (model.FormFile != null && model.FormFile.Length > 0)
                {
                    string fileName = model.FormFile.FileName;
                    var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/company", fileName);
                    var konum = dosyadakiFileName;

                    using (var akisOrtami = new FileStream(konum, FileMode.Create))
                    {
                        await model.FormFile.CopyToAsync(akisOrtami);
                    }

                    using (var memory = new MemoryStream())
                    {
                        await model.FormFile.CopyToAsync(memory);
                        model.PictureFile = memory.ToArray();
                    }

                    model.Logo = fileName;
                    model.FormFile = null;
                }


                if (model.FormFile == null)
                {
                    model.Logo = null;
                    model.PictureFile = null;
                    model.FormFile = null;
                }


                else
                {
                    ModelState.AddModelError("FormFile", "Lütfen geçerli bir fotoğraf/logo yükleyin");
                    return View(model);
                }


                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/Company/AddCompany", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CompanyList");
                }
                else
                {
                    ModelState.AddModelError("ApiError", "Şirket  eklenemedi. Lütfen tekrar deneyin.");
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

        //Ajax ile company manager doldurma
        [HttpGet]
        public async Task<IActionResult> GetCompanyManagers()
        {
            //Şirket yönetici adlarını selecte eklemek için
            var companyManagers = await _httpClient.GetFromJsonAsync<List<CompanyManagerViewModel>>("https://localhost:7136/api/CompanyManager/CompanyManagerList");
            return Json(companyManagers);
        }

        public IActionResult Details() 
        {
            return View();
        }
        
        public IActionResult Delete() 
        {
            return View();
        }
    }
}
