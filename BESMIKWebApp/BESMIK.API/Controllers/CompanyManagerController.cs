using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyManagerController : ControllerBase
    {
        private readonly BLLCompanyManager _companyManager;


        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;

        public CompanyManagerController(BLLCompanyManager companyManager, UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IUserStore<AppUser> userStore)
        {
            _companyManager = companyManager;

            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }



        [HttpGet("CompanyManagerList")]
        public async Task<ActionResult<IEnumerable<AppUserViewModel>>> GetList()
        {
            var allUsers = await _userManager.Users.Include(u => u.Company).ToListAsync();

            var users = allUsers.Where(user => _userManager.IsInRoleAsync(user, "Sirket Yoneticisi").Result).ToList();


            // var users = await _userManager.GetUsersInRoleAsync("Sirket Yoneticisi");

            //bu kısım olmadan direk users da gönderilebilir sadece appuser tablosundaki kullanmayacagımız propları ayırmak için sadece istediklerimizi ekledim.
            var userViewModels = users.Select(user => new AppUserViewModel
            {
                Name = user.Name,
                SecondName = user.SecondName,
                Surname = user.Surname,
                SecondSurname = user.SecondSurname,
                Photo = user.Photo,
                BirthDate = user.BirthDate,
                BirthPlace = user.BirthPlace,
                Tc = user.Tc,
                WorkStartDate = user.WorkStartDate,
                WorkEndDate = user.WorkEndDate,
                IsActive = user.IsActive,
                Job = user.Job,
                Department = user.Department,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Wage = user.Wage,
                PersonalEmail = user.PersonalEmail,
                CompanyId = user.CompanyId,
                Company = new CompanyViewModel
                {
                    Name = user.Company.Name
                }
            });

            return Ok(userViewModels);
        }






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
            user.PersonalEmail = model.PersonalEmail;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.Wage = model.Wage;
            user.CompanyId = model.CompanyId;


            var createMail = CreateMail(user.CompanyId.Value, user.Name, user.Surname);

            user.Email = await createMail;


            var password = "Az*123456";




            await _userStore.SetUserNameAsync(user, user.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);

            user.EmailConfirmed = true;



            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Yeni kullanıcıya sirket yoneticisi rolü atama SC
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

            user.LockoutEnabled = false;
            await _userManager.UpdateAsync(user);

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

            var result = new StringBuilder();

            foreach (var ch in input.ToLower())
            {
                result.Append(replacements.TryGetValue(ch, out var replacement) ? replacement : ch);
            }

            return result.ToString();
        }


        //ileride detay istenirse kullanabilirsin
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound();
            }


            var roles = await _userManager.GetRolesAsync(user);

            // rolunu kontrol ediyorum
            if (!roles.Contains("Sirket Yoneticisi"))
            {
                return BadRequest("Böyle bir kullanıcı bulunamadı.");
            }

            var userViewModel = new AppUserViewModel
            {
                Name = user.Name,
                SecondName = user.SecondName,
                Surname = user.Surname,
                SecondSurname = user.SecondSurname,
                Photo = user.Photo,
                BirthDate = user.BirthDate,
                BirthPlace = user.BirthPlace,
                Tc = user.Tc,
                WorkStartDate = user.WorkStartDate,
                WorkEndDate = user.WorkEndDate,
                IsActive = user.IsActive,
                Job = user.Job,
                Department = user.Department,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Wage = user.Wage,
                CompanyId = user.CompanyId
            };

            return Ok(userViewModel);
        }



        //sirket adlarını alma mvcde kullanıyorsun
        [HttpGet("CompanyNameList")]
        public ActionResult<IEnumerable<CompanyViewModel>> CompanyNameList()
        {
            var company = _companyManager.GetAll(); //mvcde namelerini çektim
            return Ok(company);
        }

    }
}
