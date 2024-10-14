using BESMIK.Entities.Concrete;
using BESMIK.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;

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

                response.Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();//kullanıcnın rolunu aldım

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




        [HttpGet("ForgotPassword/{mail}")]
        public async Task<IActionResult> ForgotPassword(string mail)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PersonalEmail == mail);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(code);
        }


        [HttpGet("FindUser/{mail}")]
        public async Task<IActionResult> FindUser(string mail)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PersonalEmail == mail);
            return Ok(user);
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PersonalEmail == model.Email);
            if (user == null)
            {
                return BadRequest("User not found.");

            }

            //var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }


    }
}
