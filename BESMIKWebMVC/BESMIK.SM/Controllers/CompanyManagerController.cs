using BESMIK.Common;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BESMIK.SM.Controllers
{
    public class CompanyManagerController : Controller
    {
        private HttpClient _httpClient;
        private IValidator<CompanyManagerViewModel> _validator;

        public CompanyManagerController(HttpClient httpClient, IValidator<CompanyManagerViewModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }


        public async Task<IActionResult> CompanyManagerList()
        {
            return View(await _httpClient.GetFromJsonAsync<List<CompanyManagerViewModel>>("https://localhost:7136/api/CompanyManager/CompanyManagerList"));
        }


        public async Task<IActionResult> CompanyManagerAdd()
        {
            return View(new CompanyManagerViewModel());
        }



        [HttpPost]
        public async Task<IActionResult> CompanyManagerAdd(CompanyManagerViewModel model)
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
                    var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/companyManager", fileName);
                    var konum = dosyadakiFileName;

                    // Kaydetmek için bir akış ortamı oluşturalım
                    using (var akisOrtami = new FileStream(konum, FileMode.Create))
                    {
                        await model.FormFile.CopyToAsync(akisOrtami);
                    }

                    using (var memory = new MemoryStream())
                    {
                        await model.FormFile.CopyToAsync(memory);
                        model.PictureFile = memory.ToArray();
                    }

                    model.Photo = fileName;
                    model.FormFile = null;
                }



                if (model.FormFile == null)
                {
                    model.Photo = null;
                    model.PictureFile = null;
                    model.FormFile = null;
                }


                //string fileName = model.FormFile.FileName;

                //var dosyadakiFileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/companyManager", fileName);

                //var konum = dosyadakiFileName;

                ////Kaydetmek için bir akış ortamı oluşturalım
                //var akisOrtami = new FileStream(konum, FileMode.Create);
                //var memory = new MemoryStream();

                ////Resmi kaydet
                //model.FormFile.CopyTo(akisOrtami);
                //model.FormFile.CopyTo(memory);

                //model.Photo = fileName;
                //model.PictureFile = memory.ToArray();
                //model.FormFile = null;

                //akisOrtami.Dispose();
                //memory.Dispose();


                else
                {
                    ModelState.AddModelError("FormFile", "Lütfen geçerli bir resim yükleyin");
                    return View(model);
                }



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
