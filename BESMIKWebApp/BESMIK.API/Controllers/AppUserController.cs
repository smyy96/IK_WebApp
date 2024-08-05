using BESMIK.BLL.Managers.Concrete;
using BESMIK.DAL;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private BesmikDbContext usermanager;
        private readonly UserManager<Entities.Concrete.AppUser> _userManager;

        public AppUserController(UserManager<Entities.Concrete.AppUser> userManager, BesmikDbContext context)
        {
            _userManager = userManager;
            usermanager = context;
        }

        [HttpGet("GetUserInfo/{name}")]
        public async Task<IActionResult> GetUserInfo(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            //var userInfo = new AppUserViewModel
            //{
            //    Name = user.UserName,
            //    Surname = user.Surname,
            //    Photo = user.Photo,
            //    BirthDate = user.BirthDate,
            //    BirthPlace = user.BirthPlace,
            //    Tc = user.Tc,
            //    WorkStartDate = user.WorkStartDate,
            //    WorkEndDate = user.WorkEndDate,
            //    IsActive = user.IsActive,
            //    Job = user.Job,
            //    Department = user.Department,
            //    Email = user.Email,
            //    Address = user.Address,
            //    Phone = user.PhoneNumber
            //};
            return Ok(user);
        }

        [HttpPut("Update/{id}")]
        public async Task <IActionResult> Guncelle(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
        {
            //var appUser = await usermanager.AppUsers.FindAsync(id);

            //if (appUser == null)
            //{
            //    return NotFound("Kullanıcı bulunamadı.");
            //}

            //if (updateUserViewModel.Photo != null)
            //    appUser.Photo = updateUserViewModel.Photo;

            //if (updateUserViewModel.Address != null)
            //    appUser.Address = updateUserViewModel.Address;

            //if (updateUserViewModel.Phone != null)
            //    appUser.PhoneNumber = updateUserViewModel.Phone;

            //usermanager.AppUsers.Update(appUser);
            await usermanager.SaveChangesAsync();

            return NoContent();

        }


    }
}
