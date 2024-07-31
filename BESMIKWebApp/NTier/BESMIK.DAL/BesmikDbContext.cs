
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace BESMIK.DAL
{
    public class BesmikDbContext : DbContext
    {
        public BesmikDbContext(DbContextOptions<BesmikDbContext> options)
    : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>()
                   .HasData(new AppUser
                   {
                       Id = 1,
                       Name = "Site",
                       SecondName = "Yöneticisi",
                       Surname = "Yönetici",
                       UserName = "siteyoneticisi",
                       NormalizedUserName = "SITEYONETICISI",
                       Email = "siteyoneticisi@mail.com",
                       NormalizedEmail = "SITEYONETICISI@MAIL.COM",
                       BirthDate = new DateOnly(2000, 1, 1),
                       BirthPlace = "Yozgat",
                       Tc = "12345678901",
                       WorkStartDate = new DateOnly(1996, 1, 1),
                       IsActive = true,
                       Job = "İK",
                       Department = Department.InsanKaynaklari,
                       Photo = null,
                       Address = "Ankara, Türkiye",
                       Phone = "+90 123 456 7890",
                       PasswordHash = hasher.HashPassword(null, "Az*123456"),
                       SecurityStamp = Guid.NewGuid().ToString(),
                   });

            // Role 
            builder.Entity<IdentityRole<int>>()
                   .HasData(new IdentityRole<int>
                   {
                       Id = 1,
                       Name = "Site Yöneticisi",
                       NormalizedName = "SITE YONETICISI"
                   });

            // Yonetici - Role 
            builder.Entity<IdentityUserRole<int>>()
                   .HasData(new IdentityUserRole<int>
                   {
                       UserId = 1,
                       RoleId = 1
                   });
        }


    }
}
