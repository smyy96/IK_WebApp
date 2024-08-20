using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("{id}")]
        public async Task<ActionResult<Spending>> GetSpendingById(int id)
        {
            var spending = _spendingService.Get(id);
            if (spending == null)
            {
                return NotFound();
            }

            var viewModel = new SpendingViewModel
            {
                Id = spending.Id,
                SpendingType = spending.SpendingType,
                Sum = spending.Sum,
                SpendingCurrency = spending.SpendingCurrency,
                SpendingStatus = spending.SpendingStatus,
                SpendingRequestDate = spending.SpendingRequestDate,
                SpendingResponseDate = spending.SpendingResponseDate,
                SpendingFile = spending.SpendingFile,
                AppUser = new AppUserViewModel
                {
                    Name = spending.AppUser?.Name,
                    Surname = spending.AppUser?.Surname
                }
            };

            return Ok(viewModel);
        }


        [HttpPost("{id}/update")]
        public async Task<ActionResult> UpdateSpendingStatus(int id, [FromBody] SpendingUpdateModel updateModel)
        {
            if (id != updateModel.Id)
            {
                return BadRequest();
            }

            var existingSpending = _spendingService.Get(id);
            if (existingSpending == null)
            {
                return NotFound();
            }

            existingSpending.SpendingStatus = updateModel.SpendingStatus;
            existingSpending.SpendingResponseDate = DateOnly.FromDateTime(DateTime.UtcNow);

            var result = _spendingService.Update(existingSpending);

            if (result > 0)
            {
                return NoContent();
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
}