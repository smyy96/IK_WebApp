using BESMIK.DAL;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DAL.Services.Concrete;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using BESMIK.BLL.Managers.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//mvc ile iletisim icin

builder.Services.AddDbContext<BesmikDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);



builder.Services.AddIdentity<AppUser, IdentityRole<int>>(
    opt =>
    {
        opt.SignIn.RequireConfirmedEmail = true;

        opt.User.RequireUniqueEmail = true;

        opt.Password.RequireDigit = true;
        opt.Password.RequireLowercase = true;
        opt.Password.RequireUppercase = true;
        opt.Password.RequireNonAlphanumeric = true;
        opt.Password.RequiredUniqueChars = 1;
        opt.Password.RequiredLength = 8;
    }
                )
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<BesmikDbContext>();






builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(Assembly)); //automapper ekleme webApp icin


builder.Services.AddScoped<CompanyRepo>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<BLLCompanyManager>();



builder.Services.AddScoped<CompanyManagerRepo>();
builder.Services.AddScoped<CompanyManagerService>();
builder.Services.AddScoped<CompanyManagerManager>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler("/Home/Error");
app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
