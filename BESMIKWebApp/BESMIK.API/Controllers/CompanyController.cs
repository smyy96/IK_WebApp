using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class CompanyController : Controller
    {
        private readonly BLLCompanyManager _companyManager;
        private CompanyManagerManager _companyManagerMan;

        public CompanyController(BLLCompanyManager companyManager, CompanyManagerManager managerManagerMan)
        {
            _companyManager = companyManager;
            _companyManagerMan = managerManagerMan;
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket ekleme

        [HttpPost("AddCompany")]
        public IActionResult Post([FromBody] CompanyViewModel companyViewModel)
        {
            _companyManager.Add(companyViewModel);
            return Created("", companyViewModel);

        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket Listeleme
        [HttpGet("CompanyList")]
        public IEnumerable<CompanyViewModel> CompanyGet()
        {
            return _companyManager.GetAll();
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirketi ID'sine göre getirme
        [HttpGet("Companies/{id}")]
        public IActionResult GetCompany(int id)
        {
            return Ok(_companyManager.Get(id));
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //ID'si seçilen şirketin yöneticilerini getirme

        [HttpGet("Companies/{id}/Managers")]
        public IActionResult GetCompanyManagers(int id)
        {
            var company = _companyManager.Get(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }

            var companyManagers = _companyManagerMan.GetManagersByCompanyID(id);
            if (!companyManagers.Any())
            {
                return NotFound("No managers found for the specified company ID.");
            }

            return Ok(companyManagers);
        }



        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket silme, (isterlerde yok)

        [HttpDelete("DeleteCompany/{id}")] //Buna anlaşılır bir isim düşünemedim, değiştirilebilir.
        public IActionResult DeleteCompany(int id)
        {
            CompanyViewModel? company = _companyManager.Get(id);

            if (company == null)
                return NotFound();

            _companyManager.Delete(company);

            return StatusCode(220, "Company deletion is completed.");
        }

    }
}
