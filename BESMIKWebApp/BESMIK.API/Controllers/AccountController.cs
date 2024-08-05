using BESMIK.Entities.Concrete;
using BESMIK.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole<int>> _roleManager;

        //private IMailService _mailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }



        [HttpPost("SignIn")]
        public IActionResult SignIn(SignInViewModel model)
        {


            AppUser? user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null) return NotFound("Kullanıcı adı veya şifre yanlıştır.");


            Microsoft.AspNetCore.Identity.SignInResult result = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true).Result;

            if (result.Succeeded)
            {
                List<Claim> claims = HttpContext.User.Claims.ToList();

                List<UserClaimViewModel> userClaimViewModel = new List<UserClaimViewModel>();

                foreach (Claim claim in claims)
                {
                    userClaimViewModel.Add(new() { Type = claim.Type, Value = claim.Value });
                }

                SignInResponseViewModel response = new SignInResponseViewModel();
                response.Claims = userClaimViewModel;
                response.BasicAuth = BasicAuthGenerate(model.Email, model.Password);

                return Ok(response);
            }

            if (result.IsNotAllowed)
            {
                return BadRequest("Mail adresiniz doğrulanmamıştır");
            }

            if (result.IsLockedOut)
            {
                return BadRequest("Hesabınız kilitlenmiştir.");
            }


            return NotFound("Kullanıcı adı veya şifre yanlıştır.");
        }

        [NonAction]
        private string BasicAuthGenerate(string email, string password)
        {
            string userInfo = email + ":" + password;

            string result = Convert.ToBase64String(Encoding.UTF8.GetBytes(userInfo)); ;

            return "Basic " + result;
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

    }
}
