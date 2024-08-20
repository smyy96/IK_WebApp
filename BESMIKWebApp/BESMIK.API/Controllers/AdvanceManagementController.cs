using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.Permission;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvanceManagementController : Controller
    {
        private readonly AdvanceManager _advanceManager;


        public AdvanceManagementController(AdvanceManager advanceManager, UserManager<AppUser> userManager)
        {
            _advanceManager = advanceManager;

        }

        [HttpPut("EditAdvance/{id}")]
        public IActionResult EditAdvance(int id, [FromBody] AdvanceViewModel guncellenmisAvans)
        {
            var varolanAvans = _advanceManager.Get(id);

            if (varolanAvans == null)
                return NotFound();

            if (varolanAvans.ApprovalStatus != guncellenmisAvans.ApprovalStatus)
            {
                varolanAvans.ApprovalStatus = guncellenmisAvans.ApprovalStatus;
                varolanAvans.AdvanceResponseDate = DateOnly.FromDateTime(DateTime.Now); 
            }

            varolanAvans.Description = guncellenmisAvans.Description;
            varolanAvans.Amount = guncellenmisAvans.Amount;
            varolanAvans.Currency = guncellenmisAvans.Currency;
            varolanAvans.AdvanceType = guncellenmisAvans.AdvanceType;
            varolanAvans.AdvanceRequestDate = guncellenmisAvans.AdvanceRequestDate;

            _advanceManager.Update(varolanAvans);

            return Ok("Avans talebi başarıyla güncellendi.");
        }   

        [HttpGet("AdvanceListByCompanyId/{companyId}")]
        public ActionResult<IEnumerable<PermissionViewModel>> GetAdvanceListWithCompany(int companyId)
        {
            var advances = _advanceManager.GetAll()
                                                       .Where(p => p.AppUser.CompanyId == companyId)
                                                       .ToList();

            return Ok(advances);
        }
    }
}
