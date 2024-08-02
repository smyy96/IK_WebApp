using BESMIK.BLL.Managers.Concrete;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManagerController : ControllerBase
    {

        private CompanyManagerManager _companyManagerManager;

        public CompanyManagerController(CompanyManagerManager companyManagerManager)
        {
            _companyManagerManager = companyManagerManager;
        }


        [HttpGet("CompanyManagerList")] //Şirket yönticisi listeleme
        public IEnumerable<CompanyManagerViewModel> GetList()
        {
            return _companyManagerManager.GetAll();
        }


        [HttpPost("CompanyManagerAdd")] // Şirkey yöneticisi ekleme
        public IActionResult Post([FromBody] CompanyManagerViewModel model)
        {
            _companyManagerManager.Add(model);
            return Ok(model);
        }

        [HttpGet("GetById/{id}")] // Id ile kişi çekme
        public IActionResult GetById(int id)
        {
            return Ok(_companyManagerManager.Get(id));
        }

    }
}
