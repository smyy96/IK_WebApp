using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

// birseyler denemek için actım sonra silecegim
namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumeyyeBirseylerDeniyorController : ControllerBase
    {
        private SignInManager<AppUser> _signIn;
        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;


        private BLLCompanyManager _companyManager;

        public SumeyyeBirseylerDeniyorController(SignInManager<AppUser> signIn, UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IUserStore<AppUser> userStore, BLLCompanyManager companyManager)
        {
            _signIn = signIn;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();

            _companyManager = companyManager;
        }


        [HttpPost("Guncelle/{username}")]
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





        [HttpPost("UserAppAdd")]
        public async Task<IActionResult> UserAppAdd([FromBody] AppUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Activator.CreateInstance<AppUser>();

            user.Name = model.Name;
            user.SecondName = model.SecondName;
            user.Surname = model.Surname;
            user.SecondSurname = model.SecondSurname;
            user.Photo = model.Photo;
            user.BirthDate = model.BirthDate;
            user.BirthPlace = model.BirthPlace;
            user.Tc = model.Tc;
            user.WorkStartDate = model.WorkStartDate;
            user.WorkEndDate = model.WorkEndDate;
            user.IsActive = model.IsActive;
            user.Job = model.Job;
            user.Department = model.Department;
            //user.Email = model.Email;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.Wage = model.Wage;
            user.CompanyId = model.CompanyId;
            var password = "Az*123456";


            //burada kullanıcının girdiiği maili mi kullanacagız yok kendimiz mi mail oluşturacagız ona göre ilerleyecegiz

            var createMail = CreateMail(user.CompanyId.Value, user.Name, user.Surname);

            user.Email = await createMail;

            await _userStore.SetUserNameAsync(user, user.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);

            user.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Yeni kullanıcıya User rolü atama SC
                if (!await _roleManager.RoleExistsAsync("Sirket Yoneticisi"))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole<int>("Sirket Yoneticisi"));
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                await _userManager.AddToRoleAsync(user, "Sirket Yoneticisi");
            }

            return Ok(model);
        }





        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;
        }












        private async Task<string> CreateMail(int id, string name, string surname)
        {
            var company = _companyManager.Get(id).Name;

            var companyName = ConvertToEnglishCharacters(company).Replace(" ", "").ToLower();
            var nameC = ConvertToEnglishCharacters(name).ToLower();
            var surnameC = ConvertToEnglishCharacters(surname).ToLower();

            string mailCreate = $"{nameC}.{surnameC}@{companyName}.com";
            int value = 0;

            while (true)
            {

                var result = await _userManager.FindByEmailAsync(mailCreate);

                if (result == null)
                {
                    break;
                }
                mailCreate = $"{name.ToLower()}.{surname.ToLower()}{value}@{companyName}.com";
                value++;
            }
            return mailCreate;
        }



        private string ConvertToEnglishCharacters(string input)
        {
            var replacements = new Dictionary<char, char>
                                {
                                    {'ı', 'i'},
                                    {'ş', 's'},
                                    {'ç', 'c'},
                                    {'ü', 'u'},
                                    {'ğ', 'g'},
                                    {'ö', 'o'},
                                    {'İ', 'i'},
                                    {'Ş', 's'},
                                    {'Ç', 'c'},
                                    {'Ü', 'u'},
                                    {'Ğ', 'g'},
                                    {'Ö', 'o'}
                                };

            // Küçük harfe dönüştür ve karakterleri değiştirmek için bir StringBuilder kullan
            var result = new StringBuilder();

            foreach (var ch in input.ToLower())
            {
                result.Append(replacements.TryGetValue(ch, out var replacement) ? replacement : ch);
            }

            return result.ToString();
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





//appuser add

//  "created": "2024-08-16T20:02:17.991Z",
//  "updated": "2024-08-16T20:02:17.991Z",
//  "name": "sumeyye",
//  "surname": "coskun",
//  "birthDate": "2024-08-16",
//  "birthPlace": "Ankara",
//  "tc": "14725836912",
//  "workStartDate": "2024-08-16",
//  "isActive": true,
//  "job": "İK",
//  "department": 1,
//  "email": "sumeyye.coskun@gmail.com",
//  "address": "Ankara",
//  "phone": "5432057599",
//  "wage": 15000,
//  "companyId": 2



//companymanager tablosu ile yapılan kısım api

/*
 using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.CompanyManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManagerController : ControllerBase
    {
        private readonly CompanyManagerManager _companyManagerService;
        private readonly BLLCompanyManager _companyManager;


        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;

        public CompanyManagerController(CompanyManagerManager companyManagerService, BLLCompanyManager companyManager,  UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IUserStore<AppUser> userStore)
        {
            _companyManagerService = companyManagerService;
            _companyManager = companyManager;

            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }



        [HttpGet("CompanyManagerList")]
        public ActionResult<IEnumerable<CompanyManagerViewModel>> GetList()
        {
            var managers = _companyManagerService.GetAll();
            return Ok(managers);

        }



        //[HttpPost("CompanyManagerAdd")]
        //public IActionResult Post([FromBody] CompanyManagerViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _companyManagerService.Add(model);
        //    return Ok(model);
        //}



        [HttpPost("CompanyManagerAdd")]
        public async Task<IActionResult> Post([FromBody] AppUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Activator.CreateInstance<AppUser>();

            user.Name = model.Name;
            user.SecondName = model.SecondName;
            user.Surname = model.Surname;
            user.SecondSurname = model.SecondSurname;
            user.Photo = model.Photo;
            user.BirthDate = model.BirthDate;
            user.BirthPlace = model.BirthPlace;
            user.Tc = model.Tc;
            user.WorkStartDate = model.WorkStartDate;
            user.WorkEndDate = model.WorkEndDate;
            user.IsActive = model.IsActive;
            user.Job = model.Job;
            user.Department = model.Department;
            user.Email = model.Email;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.Wage = model.Wage;
            user.CompanyId = model.CompanyId;
            var password = "Az*123456";




            await _userStore.SetUserNameAsync(user, user.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);

            user.EmailConfirmed = true;

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Yeni kullanıcıya User rolü atama SC
                if (!await _roleManager.RoleExistsAsync("Sirket Yoneticisi"))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole<int>("Sirket Yoneticisi"));
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                await _userManager.AddToRoleAsync(user, "Sirket Yoneticisi");
            }

            return Ok(model);
        }

        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;
        }


        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var manager = _companyManagerService.Get(id);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }



        [HttpGet("CompanyNameList")]
        public ActionResult<IEnumerable<CompanyManagerViewModel>> CompanyNameList()
        {
            var company = _companyManager.GetAll(); //mvcde namelerini çektim
            return Ok(company);
        }


    }
}

 */