using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//giriş yapan kullanıcı bilgilerini almak için açtım
namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserInfoController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
    }
}
