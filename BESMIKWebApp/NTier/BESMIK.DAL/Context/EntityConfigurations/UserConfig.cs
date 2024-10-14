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
                    PersonalEmail="siteyoneticisiyimben@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Az*123456"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true

                },
                new AppUser
                {
                    Id = 2,
                    Name = "Fadime",
                    Surname = "Güngörmemiş",
                    UserName = "personel1",
                    NormalizedUserName = "PERSONEL1",
                    Email = "fadime.gungormemis@rollinemuhendislik.com",
                    NormalizedEmail = "FADIME.GUNGORMEMIS@ROLLINEMUHENDISLIK.COM",
                    BirthDate = new DateOnly(1980, 1, 1),
                    BirthPlace = "Ankara",
                    Tc = "14725836914",
                    WorkStartDate = new DateOnly(2000, 1, 1),
                    IsActive = true,
                    Job = "Bilgisayar Mühendisi",
                    Department = Department.ArGe,
                    Photo = "AcKedi.jpg",
                    Address = "Ankara, Türkiye",
                    Phone = "+90 123 456 7890",
                    Wage = 150000,
                    PersonalEmail="fadimegungormemis@gmail.com",
                    CompanyId = 2,
                    PasswordHash = hasher.HashPassword(null, "Az*123456"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                },

                new AppUser
                {
                    Id = 3,
                    Name = "Kezban",
                    Surname = "Günyüzü",
                    UserName = "personel2",
                    NormalizedUserName = "PERSONEL2",
                    Email = "kezban.gunyuzu@rollinemuhendislik.com",
                    NormalizedEmail = "KEZBAN.GUNYUZU@ROLLINEMUHENDISLIK.COM",
                    BirthDate = new DateOnly(1980, 1, 1),
                    BirthPlace = "Ankara",
                    Tc = "14725836985",
                    WorkStartDate = new DateOnly(2000, 1, 1),
                    IsActive = true,
                    Job = "İnşaat Mühendisi",
                    Department = Department.BilgiTeknolojileri,
                    Photo = "AcKedi.jpg",
                    Address = "Ankara, Türkiye",
                    Phone = "+90 123 456 1111",
                    Wage = 250000,
                    CompanyId = 2,
                    PersonalEmail = "kezbangunyuzu@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Az*123456"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                }
                );

        }
    }
}
