using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class rolAdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: "ŞİRKET YÖNETİCİSİ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dbdb614-5d5a-4c29-a1b0-8cce19daccfe", "AQAAAAIAAYagAAAAEEzQIAAuc3Qpxay3UER1i5kFk84bk4MkOPjxwSxa9Gp9/G6z4k5Wnv76/XEfH+cnYg==", "ff7305c2-a3bb-46fd-a1c6-ed80344ad4ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc352b7-46c3-4578-a7a6-f1a39dbe7cfb", "AQAAAAIAAYagAAAAEEJpgHA9NS5KrEKWOmd08aOSZoPlj0FeCie+9bz49e5WFMG6Y1HSzXLv9I69hrYsUQ==", "13ade061-d3f4-46ee-b463-970a1fe30fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ded716b6-66ce-4246-9d9f-addfdcad6d87", "AQAAAAIAAYagAAAAEPSnkvHf74TyxQPvT48Cv+lQWO4VYUk5j3I/nw6h4i8aCFQU9o4adCGM0hhQiPbn/g==", "a717e0b8-f075-43a1-9e38-8a8f6d3bb692" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: "SIRKET YONETICISI");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "075421ed-d117-4a1c-a0ec-99f376ff9dd4", "AQAAAAIAAYagAAAAEHQOeio74XgTJodGnNioyiByQVWxJJEehKZVujJwyVKxw2UCeJPTjp0de9Zr8Fb06g==", "b781a01d-1318-4081-878a-a7acf5df9e3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01528935-3bce-4d07-bf68-ab22e2e0f8be", "AQAAAAIAAYagAAAAEHU2WvOtyGK6JOcEsyRsR7xby5xo7VBkQsn5JePI472V3FRcWAmnvbZ+Obh7N7TQTQ==", "19e6ed4b-961e-4f4e-905a-7b176d9484df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21da62de-9904-4330-9f04-36cc9f0791d1", "AQAAAAIAAYagAAAAEBKN2o4ncZp7JSBnvrDtqRpGTN4Wtx5Lkaq0vRXFtA6BDzU8QX5TCKSEVivJF5Kscw==", "373e407d-147f-4b26-996c-dd1158fc85ee" });
        }
    }
}
