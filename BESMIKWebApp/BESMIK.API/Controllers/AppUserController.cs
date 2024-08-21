using BESMIK.BLL.Managers.Concrete;
using BESMIK.DAL;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;


        public AppUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

        [HttpPut("Guncelle/{username}")]
        public async Task<IActionResult> Guncelle(string username, [FromBody] AppUserViewModel updatedUser)
        {

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("bulunamaması imkansız");
            }

            //bütün view
            user.Phone = updatedUser.Phone;
            user.Address = updatedUser.Address;
            user.Photo = updatedUser.Photo;
            user.Name = updatedUser.Name;
            user.SecondName = updatedUser.SecondName;
            user.Surname = updatedUser.Surname;
            user.SecondSurname = updatedUser.SecondSurname;
            user.BirthDate = updatedUser.BirthDate;
            user.BirthPlace = updatedUser.BirthPlace;
            user.Tc = updatedUser.Tc;
            user.WorkStartDate = updatedUser.WorkStartDate;
            user.WorkEndDate = updatedUser.WorkEndDate;
            user.IsActive = updatedUser.IsActive;
            user.Job = updatedUser.Job;
            user.Department = updatedUser.Department;
            user.Email = updatedUser.Email;


            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok("güncellendi");
            }

            return BadRequest(result.Errors.Select(e => e.Description));
        }




        [HttpPatch("Guncelle/{username}")]
        public async Task<IActionResult> Guncelle(string username, [FromBody] UpdateUserViewModel updatedUser)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("User not found");
            }


            if (!string.IsNullOrEmpty(updatedUser.Address))
            {
                user.Address = updatedUser.Address;
            }

            if (!string.IsNullOrEmpty(updatedUser.Phone))
            {
                user.PhoneNumber = updatedUser.Phone;
            }

            if (!string.IsNullOrEmpty(updatedUser.Photo))
            {
                user.Photo = updatedUser.Photo;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok("ok");
            }

            return BadRequest();
        }

    }
}









//{
//    "Phone": "+90 123 456 7890",
//  "Address": "İstanbul, Türkiye",
//  "Photo": null,
//  "Name": "Site",
//  "SecondName": "Yönetici",
//  "Surname": "Yöneticisi",
//  "SecondSurname": null,
//  "BirthDate": "2000-01-01",
//  "BirthPlace": "Yozgat",
//  "Tc": "12345678901",
//  "WorkStartDate": "1996-01-01",
//  "WorkEndDate": null,
//  "IsActive": true,
//  "Job": "İK",
//  "Department": 1,
//  "Email": "siteyoneticisi@gmail.com"
//}
