using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Permission;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly PermissionManager _permissionManagerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly BLLCompanyManager _companyManager;


        public PermissionController(PermissionManager permissionManagerService, UserManager<AppUser> userManager)
        {
            _permissionManagerService = permissionManagerService;
            _userManager = userManager;
        }

        [HttpGet("PermissionList")]
        public ActionResult<IEnumerable<PermissionViewModel>> GetList()
        {
            var permissions = _permissionManagerService.GetAll();
            return Ok(permissions);
        }
        [HttpPost("PermissionAdd")]
        public IActionResult Post([FromBody] PermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _permissionManagerService.Add(model);
            return Ok(model);
        }
        [HttpDelete("PermissionDelete{id}")]
        public IActionResult Delete(int id)
        {
            PermissionViewModel? permission = _permissionManagerService.Get(id);
            if (permission == null)
                return NotFound("izin bulunamamıştır.");
            if (permission.PermissionStatus != PermissionStatus.OnayBekliyor)
                return BadRequest("Bu izin talebini silemezsiniz.");
            else
            {
                _permissionManagerService.Delete(permission);
                return StatusCode(220, "İzin talebi silme işlemi tamamlandı.");
            }
        }
       
        [HttpPut("PermissionEdit/{id}")]
        public IActionResult Edit(int id, [FromBody] PermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permission = _permissionManagerService.Get(id);
            if (permission == null)
            {
                return NotFound("İzin bulunamamıştır.");
            }

            if (permission.PermissionStatus != PermissionStatus.OnayBekliyor)
            {
                return BadRequest("Bu izin talebine güncelleme yapamazsınız.");
            }

            permission.PermissionStartDate = model.PermissionStartDate;
            permission.PermissionEndDate = model.PermissionEndDate;
            permission.PermissionType = model.PermissionType;
            permission.OffDaysNumbers = model.OffDaysNumbers;
            permission.PermissionRequestDate= model.PermissionRequestDate;
            permission.PermissionStatus = model.PermissionStatus;
            permission.PermissionResponseDate = model.PermissionResponseDate;
            permission.AppUser = model.AppUser;


            _permissionManagerService.Update(permission);

            return Ok("İzin talebi güncelleme işlemi tamamlandı.");
        }
        [HttpGet("GetPermission/{id}")]
        public IActionResult GetPermission(int id)
        {
            var permission = _permissionManagerService.Get(id);

            if (permission == null)
                return NotFound("Avans bulunamadı.");

            if (permission.PermissionStatus != PermissionStatus.OnayBekliyor)
            {
                return StatusCode(403, "Avans düzenlenemez çünkü Avans talebi cevaplanmış/onay bekliyor durumunda değil.");
            }

            return Ok(permission);
        
        }
        [HttpGet("PermissionListByCompanyId/{companyId}")]
        public ActionResult<IEnumerable<PermissionViewModel>> GetPermissionListWithCompany(int companyId)
        {
            var permissions = _permissionManagerService.GetAll()
                                                       .Where(p => p.AppUser.CompanyId == companyId)
                                                       .ToList();

            return Ok(permissions);
        }

    }
}
