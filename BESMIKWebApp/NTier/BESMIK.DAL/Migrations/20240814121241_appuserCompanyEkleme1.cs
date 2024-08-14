using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class appuserCompanyEkleme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "3d037720-30e0-40de-936b-c5a3f24a29b2", "AQAAAAIAAYagAAAAEDwqC1UgPb/nOHB0ShfNekK/+ngH3Ac6Z7Idz6fZAwCMgECEZf6NSYW54c8MAcfdqA==", "8557ef84-5b2e-4415-92a0-6cf243b6406b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsActive", "Job", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecondName", "SecondSurname", "SecurityStamp", "Surname", "Tc", "TwoFactorEnabled", "UserName", "WorkEndDate", "WorkStartDate" },
                values: new object[] { 2, 0, "Ankara, Türkiye", new DateOnly(1980, 1, 1), "Ankara", 2, "b26c48d0-a287-4130-a8fc-366eb518db3f", 9, "personel1.personel@bilgeadam.com", true, true, "İK", false, null, "PersonelAdı 1", "PERSONEL1.PERSONEL@BILGEADAM.COM", "PERSONEL1", "AQAAAAIAAYagAAAAEJm/z4mC/CAYK9PmCf3Lo1BnDJYh7HLzjZ6U3KtwqNHa4cJ55uTqdYlSQcNfJbxBfw==", "+90 123 456 7890", null, false, null, null, null, "80a40e7e-f53c-4824-981e-46ab7a426373", "PersonelSoyadı 1", "14725836914", false, "personel1", null, new DateOnly(2000, 1, 1) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f22c2362-b641-4879-b55d-19c588771aee", "AQAAAAIAAYagAAAAEARRsQB8Q8yQRTcy1kpuPIG8QEE8V8qGGiuQqQmx6i8JTAXpybG6AP1XUDPXTJcCvA==", "74f19a10-6601-4fd8-a347-0a734bd17303" });
        }
    }
}
