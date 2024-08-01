using BESMIK.Common;
using BESMIK.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Context.EntityConfigurations
{
    public class CompanyManagerConfig : IEntityTypeConfiguration<CompanyManager>
    {
        public void Configure(EntityTypeBuilder<CompanyManager> builder)
        {
            builder.HasData(
            new CompanyManager
            {
                Id = 1,
                Name = "Ahmet",
                SecondName = "Murat",
                Surname = "Yılmaz",
                SecondSurname = "Kaya",
                Phone = "+90 532 111 2233",
                Email = "ahmet.yilmaz@teknolojiyenilikcileri.com",
                CompanyName = "Teknoloji Yenilikçileri A.Ş.",
                Photo = null,
                PictureFile = null,
                BirthDate = new DateOnly(1985, 7, 15),
                BirthPlace = "Ankara",
                TC = "12345678901",
                WorkStartDate = new DateOnly(2010, 9, 1),
                Department = Department.ArGe,
                CompanyId = 1 
            },
            new CompanyManager
            {
                Id = 2,
                Name = "Elif",
                SecondName = "Nur",
                Surname = "Demir",
                SecondSurname = "Yıldız",
                Phone = "+90 212 333 4455",
                Email = "elif.demir@rollinemuhendislik.com",
                CompanyName = "Rolline Mühendislik Ltd.",
                Photo = null,
                PictureFile = null,
                BirthDate = new DateOnly(1990, 4, 20),
                BirthPlace = "İstanbul",
                TC = "98765432109",
                WorkStartDate = new DateOnly(2015, 6, 15),
                Department = Department.SatınAlma,
                CompanyId = 2 
            }
        );
        }
    }
}
