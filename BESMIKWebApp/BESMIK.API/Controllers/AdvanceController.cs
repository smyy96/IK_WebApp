using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.Company;
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

            _advanceManager.Add(model);
            return Ok(model);
        }


        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Taleplerini Listeleme (Her personelin id'sine göre geliyor.)
        [HttpGet("AdvancesList/{userId}")]
        public ActionResult<IEnumerable<AdvanceViewModel>> AdvanceGet(int userId)
        {
            var advances = _advanceManager.GetAll()
                                          .Where(a => a.AppUserId == userId)
                                          .ToList();
            return Ok(advances);
        }


        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans Talebi çağırma (id'ye göre)
        [HttpGet("GetAdvance/{id}")]
        public IActionResult GetAdvance(int id)
        {
            var advance = _advanceManager.Get(id);

            if (advance == null)
                return NotFound("Avans bulunamadı.");

            if (advance.ApprovalStatus != AdvanceApprovalStatus.OnayBekliyor)
            {
                return StatusCode(403, "Avans düzenlenemez çünkü Avans talebi cevaplanmış/onay bekliyor durumunda değil.");
            }

            return Ok(advance);
        }


        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //İsme göre personel bilgileri çağırma
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

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Id'ye göre personel çağırma
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

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Id'ye göre personel maaşı bilgisini çağırma
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

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans talebi silme
        [HttpDelete("DeleteAdvance/{id}")] 
        public IActionResult DeleteAdvance(int id)
        {
            AdvanceViewModel? advance = _advanceManager.Get(id);

            if (advance == null)
                return NotFound();

            _advanceManager.Delete(advance);

            return StatusCode(220, "Avans talebi silme işlemi tamamlandı.");
        }

        //*--------------------------------------------------------------------------------------------------------------------------------------------*
        //Avans talebi düzenleme (sadece onay bekliyorsa)
        [HttpPut("EditAdvance/{id}")]
        public IActionResult EditAdvance(int id, [FromBody] AdvanceViewModel guncellenmisAvans)
        {
            var varolanAvans = _advanceManager.Get(id);

            if (varolanAvans == null)
                return NotFound();

            varolanAvans.Description = guncellenmisAvans.Description;
            varolanAvans.Amount = guncellenmisAvans.Amount;
            varolanAvans.Currency = guncellenmisAvans.Currency;
            varolanAvans.AdvanceType = guncellenmisAvans.AdvanceType;
            varolanAvans.ApprovalStatus = guncellenmisAvans.ApprovalStatus;
            varolanAvans.AdvanceRequestDate = guncellenmisAvans.AdvanceRequestDate;

            _advanceManager.Update(varolanAvans);

            return Ok("Avans talebi başarıyla güncellendi.");
        }


    }
}
