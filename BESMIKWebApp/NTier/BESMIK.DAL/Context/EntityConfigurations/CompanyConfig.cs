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
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
            new Company
            {
                Id = 1,
                Name = "Teknoloji Yenilikçileri",
                TitleName = "A.Ş.",
                MersisNumber = "1234567890123456",
                TaxNumber = "1234567890",
                TaxAdministration = "Ankara",
                Logo = null,
                PictureFile = null, 
                Phone = "+90 312 555 1234",
                Address = "Ankara, Türkiye",
                Email = "info@teknolojiyenilikcileri.com",
                EmployeesNumber = "50",
                EstablishmentYear = new DateOnly(2010, 5, 1),
                ContractStartYear = new DateOnly(2020, 1, 1),
                ContractEndYear = new DateOnly(2025, 1, 1),
                IsActive = true
            },
            new Company
            {
                Id = 2,
                Name = "Rolline Mühendislik",
                TitleName = " Ltd.",
                MersisNumber = "9876543210987654",
                TaxNumber = "0987654321",
                TaxAdministration = "İstanbul",
                Logo = null,
                PictureFile = null,
                Phone = "+90 212 444 5678",
                Address = "İstanbul, Türkiye",
                Email = "info@rollinemuhendislik.com",
                EmployeesNumber = "200",
                EstablishmentYear = new DateOnly(2005, 8, 15),
                ContractStartYear = new DateOnly(2019, 3, 1),
                ContractEndYear = new DateOnly(2024, 3, 1),
                IsActive = true
            });
        }
    }
}
