using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
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
        //private CompanyManagerManager _companyManagerMan;

        public CompanyController(BLLCompanyManager companyManager)
        {
            _companyManager = companyManager;
           // _companyManagerMan = managerManagerMan;
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket ekleme

        [HttpPost("AddCompany")]
        public IActionResult Post([FromBody] CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _companyManager.Add(model);
            return Ok(model);
        }

        //[HttpPost("AddCompany")]
        //public IActionResult Post([FromBody] CompanyViewModel companyViewModel)
        //{
        //    _companyManager.Add(companyViewModel);
        //    return CreatedAtAction(nameof(GetCompany), new { id = companyViewModel.Id }, companyViewModel);
        //}

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirket Listeleme
        [HttpGet("CompanyList")]
        public ActionResult<IEnumerable<CompanyViewModel>> CompanyGet()
        {
            return Ok(_companyManager.GetAll());
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Şirketi ID'sine göre getirme
        [HttpGet("{id}")]
        public ActionResult<CompanyViewModel> GetCompany(int id)
        {
            var company = _companyManager.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }



        //company manager tablosu silinidigi için kaldırdım sc
        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //ID'si seçilen şirketin yöneticilerini getirme
        //[HttpGet("{id}/Managers")]
        //public ActionResult<IEnumerable<CompanyManagerViewModel>> GetCompanyManagers(int id)
        //{
        //    var company = _companyManager.Get(id);
        //    if (company == null)
        //    {
        //        return NotFound("Company not found.");
        //    }

        //    var companyManagers = _companyManagerMan.GetManagersByCompanyID(id);
        //    if (companyManagers == null || !companyManagers.Any())
        //    {
        //        return NotFound("No managers found for the specified company ID.");
        //    }

        //    return Ok(companyManagers);
        //}

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
