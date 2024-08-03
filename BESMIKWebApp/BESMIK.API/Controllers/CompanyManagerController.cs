using BESMIK.BLL.Managers.Concrete;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManagerController : ControllerBase
    {
        private readonly CompanyManagerManager _companyManagerService;
        private readonly CompanyManager _companyManager;


        public CompanyManagerController(CompanyManagerManager companyManagerService, CompanyManager companyManager)
        {
            _companyManagerService = companyManagerService;
            _companyManager = companyManager;
        }



        [HttpGet("CompanyManagerList")]
        public ActionResult<IEnumerable<CompanyManagerViewModel>> GetList()
        {
            var managers = _companyManagerService.GetAll();
            return Ok(managers);

        }



        [HttpPost("CompanyManagerAdd")]
        public IActionResult Post([FromBody] CompanyManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _companyManagerService.Add(model);
            return Ok(model);
        }



        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var manager = _companyManagerService.Get(id);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }



        [HttpGet("CompanyNameList")]
        public ActionResult<IEnumerable<CompanyManagerViewModel>> CompanyNameList()
        {
            var company = _companyManager.GetAll(); //mvcde namelerini çektim
            return Ok(company);
        }


    }
}
