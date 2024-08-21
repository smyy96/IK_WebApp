using BESMIK.ViewModel.Company;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.SM.Controllers
{
    [Authorize(Roles = "Site Yoneticisi")]
    public class CompaniesController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<CompanyViewModel> _validator;

        public CompaniesController(HttpClient httpClient, IValidator<CompanyViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> CompaniesList()
        {
            var companies = await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/api/Company/CompanyList");
            return View(companies);
        }


        //public async Task<IActionResult> CompanyDetails()
        //{
        //    return View(await _httpClient.GetFromJsonAsync<List<CompanyViewModel>>("https://localhost:7136/api/Company/CompanyList"));
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> CompanyDetails(int id)
        {
            var company = await _httpClient.GetFromJsonAsync<CompanyViewModel>($"https://localhost:7136/api/Company/{id}");
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
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

                ModelState.Remove("Logo");
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



                else if (model.FormFile == null || model.FormFile.Length == 0)
                {
                    model.Logo = null;
                    model.PictureFile = null;

                    ModelState.AddModelError("FormFile", "Lütfen geçerli bir resim yükleyin.");
                    return View(model);
                }


                var response = await _httpClient.PostAsJsonAsync("https://localhost:7136/api/Company/AddCompany", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CompaniesList");
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

    }
}
