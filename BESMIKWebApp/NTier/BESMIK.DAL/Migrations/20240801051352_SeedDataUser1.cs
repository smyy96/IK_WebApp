using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsActive", "Job", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecondName", "SecondSurname", "SecurityStamp", "Surname", "Tc", "TwoFactorEnabled", "UserName", "WorkEndDate", "WorkStartDate" },
                values: new object[] { 1, 0, "Ankara, Türkiye", new DateOnly(2000, 1, 1), "Yozgat", "f69af096-8130-4ad0-a1f5-c8f20324cfd5", 1, "siteyoneticisi@mail.com", true, true, "İK", false, null, "Site", "SITEYONETICISI@MAIL.COM", "SITEYONETICISI", "AQAAAAIAAYagAAAAEBojBYQTYOzaAT6sXHelbzQwWfhfZOIUzGK4Fn/LxDiNdjg0SygJ7Y9TXQ/NpL4iAA==", "+90 123 456 7890", null, false, null, "Yöneticisi", null, "742e0232-ab95-445e-90d9-6293e11ec0be", "Yönetici", "12345678901", false, "siteyoneticisi", null, new DateOnly(1996, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
