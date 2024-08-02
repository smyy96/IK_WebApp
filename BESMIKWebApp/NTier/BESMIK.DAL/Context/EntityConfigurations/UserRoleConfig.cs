﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BESMIK.DAL.Context.EntityConfigurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1
                }
            );
        }
    }
}