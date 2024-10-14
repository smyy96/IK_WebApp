using BESMIK.DAL;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DAL.Services.Concrete;
using BLLCompanyManager = BESMIK.BLL.Managers.Concrete.CompanyManager;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using BESMIK.BLL.Managers.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//mvc ile iletisim icin

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

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
    })
     .AddRoles<IdentityRole<int>>()
     .AddEntityFrameworkStores<BesmikDbContext>()
     .AddDefaultTokenProviders();




// JWT Ayarlarý
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(Assembly)); //automapper ekleme webApp icin


builder.Services.AddScoped<CompanyRepo>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<BLLCompanyManager>();



//builder.Services.AddScoped<CompanyManagerRepo>();
//builder.Services.AddScoped<CompanyManagerService>();
//builder.Services.AddScoped<CompanyManagerManager>();



builder.Services.AddScoped<PermissionRepo>();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<PermissionManager>();


builder.Services.AddScoped<AdvanceRepo>();
builder.Services.AddScoped<AdvanceService>();
builder.Services.AddScoped<AdvanceManager>();


builder.Services.AddScoped<SpendingRepo>();
builder.Services.AddScoped<SpendingService>();
builder.Services.AddScoped<SpendingManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseCors();//sc

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
