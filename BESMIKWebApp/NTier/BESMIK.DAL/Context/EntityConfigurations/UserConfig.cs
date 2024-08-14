using BESMIK.Common;
using BESMIK.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    Name = "Site",
                    SecondName = "Yöneticisi",
                    Surname = "Yönetici",
                    UserName = "siteyoneticisi",
                    NormalizedUserName = "SITEYONETICISI",
                    Email = "site.yoneticisi@bilgeadam.com",
                    NormalizedEmail = "SITE.YONETICISI@BILGEADAM.COM",
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
                    EmailConfirmed = true
                },
                new AppUser
                {
                    Id = 2,
                    Name = "PersonelAdı 1",
                    Surname = "PersonelSoyadı 1",
                    UserName = "personel1",
                    NormalizedUserName = "PERSONEL1",
                    Email = "personel1.personel@bilgeadam.com",
                    NormalizedEmail = "PERSONEL1.PERSONEL@BILGEADAM.COM",
                    BirthDate = new DateOnly(1980, 1, 1),
                    BirthPlace = "Ankara",
                    Tc = "14725836914",
                    WorkStartDate = new DateOnly(2000, 1, 1),
                    IsActive = true,
                    Job = "İK",
                    Department = Department.ArGe,
                    Photo = null,
                    Address = "Ankara, Türkiye",
                    Phone = "+90 123 456 7890",
                    CompanyId = 2,
                    PasswordHash = hasher.HashPassword(null, "Az*123456"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                }


                );

        }
    }
}
