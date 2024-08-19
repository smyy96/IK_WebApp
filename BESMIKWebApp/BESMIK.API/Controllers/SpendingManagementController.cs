using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingManagementController : Controller
    {
        private readonly SpendingManager _spendingService;
        private readonly UserManager<AppUser> _userManager;

        public SpendingManagementController(SpendingManager spendingService, UserManager<AppUser> userManager)
        {
            _spendingService = spendingService;
            _userManager = userManager;
        }

        [HttpGet("SpendingListForManager/{companyId}")]
        public async Task<ActionResult<IEnumerable<Spending>>> GetSpendingListForManager(int CompanyId)
        {
            var spendings=_spendingService.GetAll()
                .Where(s => s.AppUser.CompanyId == CompanyId)
                .ToList();

            return Ok(spendings);
        }

    }
}