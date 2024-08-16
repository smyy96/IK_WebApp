using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.EntityConfigurations
{
    public class RoleConfig : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Site Yoneticisi",
                    NormalizedName = "SITE YONETICISI"
                },

                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Sirket Yoneticisi",
                    NormalizedName = "SIRKET YONETICISI"
                },

                new IdentityRole<int>
                {
                    Id = 3,
                    Name = "Personel",
                    NormalizedName = "PERSONEL"
                });
        }
    }
}
