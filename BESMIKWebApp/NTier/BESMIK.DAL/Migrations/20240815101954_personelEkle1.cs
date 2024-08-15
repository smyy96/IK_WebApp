using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personelEkle1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07ed98a5-f169-4754-8424-a98a362d7b27", "AQAAAAIAAYagAAAAEHc0ljg+3o1hQKz2psi9yp3l4q/ZqaTHpQg486L3OqO8ngraGkGpNkG7NesPwzt+JA==", "c06598f2-dfff-418f-954d-5caaa0fd8769" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80e74596-294a-4183-9263-da969b330fc3", "AQAAAAIAAYagAAAAEJD5IYol1I7QZv+nUVf5/Zj6WuHMdoZmR+0Btsngo5I4FOP2jlr9WDKld6gvbdffoQ==", "d935ff2b-f242-4690-8fa9-235deacffa1f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyId", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "IsActive", "Job", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecondName", "SecondSurname", "SecurityStamp", "Surname", "Tc", "TwoFactorEnabled", "UserName", "Wage", "WorkEndDate", "WorkStartDate" },
                values: new object[] { 3, 0, "Ankara, Türkiye", new DateOnly(1980, 1, 1), "Ankara", 2, "7e90f814-ef3a-4017-8bee-a72e12978f75", 3, "personel2.personel@bilgeadam.com", true, true, "İnşaat Mühendisi", false, null, "Kezban", "PERSONEL2.PERSONEL@BILGEADAM.COM", "PERSONEL2", "AQAAAAIAAYagAAAAEBAG9LitwsffRgPuZQAQd+i6PuwELUSQklyxJKWSEEs+u4KDMAxyVa6c/9nvMDS4GA==", "+90 123 456 1111", null, false, "AcKedi.jpg", null, null, "3027cfc9-3a49-4dd4-a1f1-d8a5fc126c0b", "Günyüzü", "14725836985", false, "personel2", 250000f, null, new DateOnly(2000, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78d590c2-c9f3-43c1-987a-d86bf10c8110", "AQAAAAIAAYagAAAAEC7jsNhTc8WRSSpiwkDeIe08ByTwfKpgC+Mk5leIT/LMukXFHfV12CqeffbTxOSdGA==", "bf2ce92e-be2c-4b71-b3a3-3f4b9649e483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41e141c9-bd89-4af2-970d-1af6197a4cb2", "AQAAAAIAAYagAAAAEDE7d46ctHwTMRgRpBggEEZU7k/0WQfAjJ65uu8W/1pAAKXOBj5FUhm9k4OxwXeG7Q==", "1a0eeb2c-71a9-4e7d-b358-bcaa6867a84f" });
        }
    }
}
