using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CompanyandCManagerSeedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureFile",
                table: "CompanyManagers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureFile",
                table: "Companies",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6048a601-3c00-4ab7-acf0-c2ad5406907b", "AQAAAAIAAYagAAAAEOSmqYJTcEAvGSbAC/juKaLkXt2mrFF5DcaJFh36VlpY0nWNlQaWtGIL19eImPvzcQ==", "c6c7cea5-048d-4beb-bdc3-72eb1a362926" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "ContractEndYear", "ContractStartYear", "Created", "Email", "EmployeesNumber", "EstablishmentYear", "IsActive", "Logo", "MersisNumber", "Name", "Phone", "PictureFile", "TaxAdministration", "TaxNumber", "TitleName", "Updated" },
                values: new object[,]
                {
                    { 1, "Ankara, Türkiye", new DateOnly(2025, 1, 1), new DateOnly(2020, 1, 1), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@teknolojiyenilikcileri.com", "50", new DateOnly(2010, 5, 1), true, null, "1234567890123456", "Teknoloji Yenilikçileri A.Ş.", "+90 312 555 1234", null, "Ankara", "1234567890", "Teknoloji Yenilikçileri", null },
                    { 2, "İstanbul, Türkiye", new DateOnly(2024, 3, 1), new DateOnly(2019, 3, 1), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@rollinemuhendislik.com", "200", new DateOnly(2005, 8, 15), true, null, "9876543210987654", "Rolline Mühendislik Ltd.", "+90 212 444 5678", null, "İstanbul", "0987654321", "Rolline Mühendislik", null }
                });

            migrationBuilder.InsertData(
                table: "CompanyManagers",
                columns: new[] { "Id", "BirthDate", "BirthPlace", "CompanyId", "CompanyName", "Created", "Department", "Email", "Name", "Phone", "Photo", "PictureFile", "SecondName", "SecondSurname", "Surname", "TC", "Updated", "WorkStartDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(1985, 7, 15), "Ankara", 1, "Teknoloji Yenilikçileri A.Ş.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "ahmet.yilmaz@teknolojiyenilikcileri.com", "Ahmet", "+90 532 111 2233", null, null, "Murat", "Kaya", "Yılmaz", "12345678901", null, new DateOnly(2010, 9, 1) },
                    { 2, new DateOnly(1990, 4, 20), "İstanbul", 2, "Rolline Mühendislik Ltd.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "elif.demir@rollinemuhendislik.com", "Elif", "+90 212 333 4455", null, null, "Nur", "Yıldız", "Demir", "98765432109", null, new DateOnly(2015, 6, 15) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureFile",
                table: "CompanyManagers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureFile",
                table: "Companies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a88f56-2aad-47bb-8c6e-6a62eed1717c", "AQAAAAIAAYagAAAAECISDkM0qUYPjpqE23EJ3k+tXagGhw+PGBTcYHUsm68kBfsBz93R5h22h1YCfcySGg==", "c5b35766-793e-432b-8608-b28b84e9174c" });
        }
    }
}
