using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly AdvanceManager _advanceManager;
        private readonly UserManager<AppUser> _userManager;


        public AdvanceController(AdvanceManager advanceManager, UserManager<AppUser> userManager)
        {
            _advanceManager = advanceManager;
            _userManager = userManager;

        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Talebi ekleme

        [HttpPost("AddAdvance")]
        public IActionResult Post([FromBody] AdvanceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Assuming the advance is associated with the AppUserId correctly in the Add method of AdvanceManager
            _advanceManager.Add(model);
            return Ok(model);
        }


        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Taleplerini Listeleme
        [HttpGet("AdvancesList/{userId}")]
        public ActionResult<IEnumerable<AdvanceViewModel>> AdvanceGet(int userId)
        {
            var advances = _advanceManager.GetAll()
                                          .Where(a => a.AppUserId == userId)
                                          .ToList();
            return Ok(advances);
        }


        [HttpGet("GetUserInfo/{name}")]
        public async Task<IActionResult> GetUserInfo(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            //await _userManager.
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            return Ok(user);

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


        [HttpGet("GetUserWage/{id}")]
        public async Task<IActionResult> GetUserWage(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            return Ok(user.Wage);
        }

    }
}
