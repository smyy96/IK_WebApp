
using BESMIK.SM.UserProfileViewComponent;
using BESMIK.SM.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Kullanýcý oturum açmamýþsa bu sayfa acýlacak
                options.AccessDeniedPath = "/Account/AccessDenied"; // Eriþim reddedildiðinde acýlacak sayfa
            });

builder.Services.AddAuthorization();

builder.Services.AddHttpClient<UserProfileViewComponent>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler
        {
            UseCookies = false // MVC'nin oturum çerezlerini kullanmasýný saðlar
        };
        return handler;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); //session

app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization();  // Yetkilendirme


// Rota düzenlemesi
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


// Ana rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
