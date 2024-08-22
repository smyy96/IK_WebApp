using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
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



        [HttpPut("EditSpending/{id}")]
        public IActionResult EditSpending(int id, [FromBody] SpendingViewModel updatedSpending)
        {
            var mevcutHarcama = _spendingService.Get(id);

            if (mevcutHarcama == null)
                return NotFound();

            mevcutHarcama.SpendingType = updatedSpending.SpendingType;
            mevcutHarcama.Sum = updatedSpending.Sum;
            mevcutHarcama.SpendingCurrency = updatedSpending.SpendingCurrency;
            mevcutHarcama.SpendingFile = updatedSpending.SpendingFile;
            mevcutHarcama.SpendingStatus = updatedSpending.SpendingStatus;
            mevcutHarcama.SpendingResponseDate = updatedSpending.SpendingResponseDate;
            mevcutHarcama.SpendingRequestDate = updatedSpending.SpendingRequestDate;

            _spendingService.Update(mevcutHarcama);

            return Ok("harcama başarıyla güncellendi.");
        }


        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            return Ok(user);
        }

        [HttpGet("GetSpending/{id}")]
        public IActionResult GetSpending(int id)
        {
            var spending = _spendingService.Get(id);

            if (spending == null)
                return NotFound("harcama bulunamadı.");

            if (spending.SpendingStatus != SpendingStatus.OnayBekliyor)
            {
                return StatusCode(403, "Harcama talebi onay bekliyor statüsünde değil.");
            }

            return Ok(spending);
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

    }
}