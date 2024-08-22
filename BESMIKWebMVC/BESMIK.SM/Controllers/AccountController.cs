using BESMIK.SM.Models;
using BESMIK.ViewModel;
using BESMIK.ViewModel.AppUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BESMIK.SM.Controllers
{
    public class AccountController : Controller
    {


        private HttpClient _httpClient;
        private IValidator<ResetPasswordModel> _validator;

        public AccountController(HttpClient httpClient, IValidator<ResetPasswordModel> validator)
        {
            _httpClient = httpClient;
            _validator = validator;
        }


        public IActionResult Index()
        {
            //https://localhost:7136/api/Account/SignIn  https://localhost:7136/api/Account/Logout
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7136/"); //Api url

            SignInViewModel signInViewModel = new SignInViewModel();
            signInViewModel.Email = email;
            signInViewModel.Password = password;


            string modelJson = JsonSerializer.Serialize(signInViewModel);

            StringContent content = new StringContent(modelJson, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await httpClient.PostAsync("/api/Account/SignIn", content);

            if (responseMessage != null && responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {

                SignInResponseViewModel responseViewModel = responseMessage.Content.ReadFromJsonAsync<SignInResponseViewModel>().Result;

                List<Claim> claims = new List<Claim>();

                foreach (UserClaimViewModel item in responseViewModel.Claims)
                {
                    Claim claim = new Claim(item.Type, item.Value);
                    claims.Add(claim);
                }


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("BasicAuth", responseViewModel.BasicAuth);

                if (responseViewModel.Role == "Personel")
                {
                    return RedirectToAction("Index", "PersonalHome", new { area = "Personal" });

                }

                else if (responseViewModel.Role == "Site Yoneticisi")
                {
                    return RedirectToAction("Summary", "AppUser");
                }

                else if (responseViewModel.Role == "Sirket Yoneticisi")
                {
                    return RedirectToAction("Index", "CompanyManagerHome", new { area = "CompanyManager" });
                }

            }

            TempData["ErrorMessage"] = "Kullanıcı bulunamadı veya geçersiz şifre!";
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            HttpClient _httpClient = new HttpClient();

            await HttpContext.SignOutAsync(); //mvc cıkıs

            //apiden logout
            try
            {
                var response = await _httpClient.PostAsync("https://localhost:7136/api/Account/Logout", null);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = "Logout başarısız.";
                    return RedirectToAction("Index", "ErrorPages");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Bir hatalar var :(";
                return RedirectToAction("Index", "ErrorPages");
            }

            // login sayfasına yönlendirme
            return RedirectToAction("Login", "Account");

        }


        ////Erişim hatası
        public IActionResult AccessDenied()
        {
            var user = HttpContext.User;

            return View();
        }





        public IActionResult ForgotPassword()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {


                var response = await _httpClient.GetAsync($"https://localhost:7136/api/Account/ForgotPassword/{model.Email}");

                if (response.IsSuccessStatusCode)
                {
                    var code = await response.Content.ReadAsStringAsync();
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    //var callbackUrl = Url.Page(
                    //    "/Account/ResetPassword",
                    //    pageHandler: null,
                    //    values: code,
                    //    protocol: Request.Scheme);




                    var callbackUrl = Url.Action(
                        "ResetPassword",        // Action Name
                        "Account",              // Controller Name
                        new { code = code, email = model.Email },    // Route Values
                        protocol: Request.Scheme);


                    MailSender(model.Email, "Şifre Resetleme", callbackUrl);

                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"API Error: {errorMessage}");
                    TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                    return RedirectToAction("ForgotPassword");
                }
            }

            return RedirectToAction("ForgotPasswordConfirmation");
        }


        public void MailSender(string email, string subject, string callbackUrl)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            var sender = "besmikapp@gmail.com";

            mailMessage.From = new MailAddress(sender, "BESMIK APP");//Kimden 
            mailMessage.To.Add(email);//Kime
            mailMessage.Subject = subject;
            mailMessage.Body = $@"
                <div style='font-family: Arial, sans-serif; line-height: 1.5;'>
                    <p>Şifrenizi resetlemek için lütfen aşağıdaki linke tıklayınız:</p>
                    <p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}' style='color: #1a73e8;'>Şifreyi Resetle</a></p>
                    <p><img src='https://r.resimlink.com/IkSGLXz.png' alt='Image' style='max-width: 100%; height: auto;' /></p>
                </div>";
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential(sender, "pkzzceoypzicusvv");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Send(mailMessage);
        }




        [HttpGet]
        public IActionResult ResetPassword(string code = null, string email = null)
        {
            if (code == null)
            {
                return BadRequest("Resetlenme işlemi gerçekleşmedi tekrar deneyiniz.");
            }
            else
            {
                var model = new ResetPasswordModel
                {
                    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)),
                    Email = email
                    //Code = code
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            ValidationResult resultValid = _validator.Validate(model);

            if (!ModelState.IsValid)
            {
                ModelState.Clear();

                resultValid.AddToModelState(ModelState);
                return View(model);
            }


            var user = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Account/FindUser/{model.Email}");


            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(model);
            }

            var result = await _httpClient.PostAsJsonAsync($"https://localhost:7136/api/Account/ResetPassword", model);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var errorResponse = await result.Content.ReadFromJsonAsync<ErrorResponse>();

            if (errorResponse != null && errorResponse.Errors.Any())
            {
                foreach (var error in errorResponse.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            TempData["ErrorMessage"] = "Hata Oluştu Tekrar Deneyiniz.";

            return View(model);
        }




        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}
