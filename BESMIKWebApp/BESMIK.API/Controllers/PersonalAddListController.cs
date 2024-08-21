using BESMIK.BLL.Managers.Concrete;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BESMIK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalAddListController : Controller
    {
        private readonly CompanyManager _companyManager;

        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;

        public PersonalAddListController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IUserStore<AppUser> userStore, CompanyManager companyManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _companyManager = companyManager;
        }

        [HttpGet("PersonalList/{companyid}")]
        public async Task<ActionResult<IEnumerable<AppUserViewModel>>> GetList(int companyid)
        {
            var allUsers = await _userManager.Users.Where(c => c.CompanyId == companyid).ToListAsync();

            var users = allUsers.Where(user => _userManager.IsInRoleAsync(user, "Personel").Result).ToList();

            return Ok(users);
        }






        [HttpPost("PersonalAdd")]
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



            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Yeni kullanıcıya personel rolü atama 
                await _userManager.AddToRoleAsync(user, "Personel");

                //Mail Gönderimi yapılır
                string token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result; //token oluşturma mail confirm için. oluşan tokena tıklanıldıgı zaman mail confirm olacak



                string link = Url.ActionLink("ValidationEmail", "PersonalAddList", new { UserMail = user.PersonalEmail, Token = token, returnUrl = "https://localhost:7177/Account/Login/Account/Login" }, protocol: HttpContext.Request.Scheme); //endpoint oluşturuyoruz. link maile gidecek olan dogrulama linkidir.

                MailGonder(user.Email, user.PersonalEmail, user.Name + " " + user.Surname, link);

            }

            user.LockoutEnabled = false;
            await _userManager.UpdateAsync(user);

            return Ok(model);
        }


        private void MailGonder(string companyMail, string mail, string displayName, string link)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("besmikapp@gmail.com", "pkzzceoypzicusvv"); //mail ve uygulama sifresi

            MailAddress from = new MailAddress("besmikapp@gmail.com", "BESMIK APP");
            MailAddress to = new MailAddress(mail, displayName);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Mail Aktivasyonu";
            message.Body = $@"<p>Merhaba {displayName},</p>
                              <p>Sistemimize başarıyla kayıt oldunuz. Email adresiniz doğrulayarak giriş yapabilirsiniz.</p>
                              <p>Onay için <a href=""{link}"">tıklayınız.</a> </p> 
                                <br>
                                <p>
                                Şifreniz: <strong>Az*123456</strong> <br>
                                Mail Adresiniz: <strong>{companyMail}</strong>
                                 </p>
                              <img src='https://r.resimlink.com/IkSGLXz.png' />";
            //message.Body = RenderMailBody();
            message.IsBodyHtml = true;

            smtpClient.Send(message);

        }




        ////mail adresine gelen dogrulama linkine tıkladıktan sonra yapılacak olan yönlendirme kısmı
        //[HttpGet("ValidationEmail")]
        //public IActionResult ValidationEmail(string usermail, string token, string returnUrl)
        //{
        //    //AppUser? user = _userManager.FindByEmailAsync(usermail).Result;
        //    AppUser? user = _userManager.Users.FirstOrDefault(u => u.PersonalEmail == usermail);

        //    if (user == null)
        //    {
        //        return BadRequest("Kullanıcı bulunmadı");
        //    }

        //    //mailin dogrulama işlemini gercekleştiriyor
        //    IdentityResult result = _userManager.ConfirmEmailAsync(user, token).Result;

        //    if (!result.Succeeded)
        //    {

        //        StringBuilder errorSb = new StringBuilder();

        //        foreach (var error in result.Errors)
        //        {
        //            errorSb.Append(error.Code + " " + error.Description + "<br>");
        //        }
        //        return BadRequest(errorSb.ToString());
        //    }

        //    return Ok("Onaylandı");
        //}




        [HttpGet("ValidationEmail")]
        public async Task<IActionResult> ValidationEmail(string usermail, string token, string returnUrl)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PersonalEmail == usermail);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => $"{e.Code} {e.Description} <br> Mail adresi başka bir kullanıcıda mevcut olabilir ya da token süresi dolmuştur yeniden kayıt açınız.");
                return BadRequest(string.Join("<br>", errorMessages));
            }

            // kullanıcıyı login sayfasına yönlendirme
            return Redirect("https://localhost:7177/Account/Login");
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
            int value = 1;

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

    }
}
