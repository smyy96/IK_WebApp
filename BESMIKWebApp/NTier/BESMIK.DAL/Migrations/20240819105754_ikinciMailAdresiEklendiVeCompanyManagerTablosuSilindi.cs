using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ikinciMailAdresiEklendiVeCompanyManagerTablosuSilindi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyManagers");

            migrationBuilder.AddColumn<string>(
                name: "PersonalEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "323147d1-b0ac-4e4e-809e-f45e47491197", "AQAAAAIAAYagAAAAEOlF+ZdD2JoNhqWa2M2sxxnluaBrJym8EnCoF+rTUuhIURAI2hFtDLqa6ZvovR02lQ==", null, "37461e03-e5cd-4f5d-965c-b5d0670f1969" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "df377f4d-b536-4aeb-9a46-5e6961e22982", "AQAAAAIAAYagAAAAEDCoc6oEpzol4mY1KVr6aY6BCHoYyfqD4J5Y3yuxqLH2C3lMYEIlihfqlXPh26LIww==", null, "d0da89bc-ec2c-4004-adba-0b5b6261c5af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "7f657a8b-da63-4c9c-b48d-a228bad49a6e", "AQAAAAIAAYagAAAAEAShjV5jYYQv40D2JjnoEIC6i4WWPYO7Kgdf/OquYvMpUVAgU2x4AEKcoT93RXXifQ==", null, "dd88b877-fc6d-4217-ad74-565544827a08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalEmail",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CompanyManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStartDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyManagers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86be6d25-09b8-4589-84f2-bd01addd43bd", "AQAAAAIAAYagAAAAED2KHsN3nv2hEsTZjxI/zSua4hWfGSH3slwB8eLSt5kFVQRsxkCEBqAD9BosKG2V+g==", "d07a451a-151f-457c-90e5-6ab39048d784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a2ebd25-d259-4890-bbf6-836c29d0ea05", "AQAAAAIAAYagAAAAEPW5evq7PTrDF7doXizOdiQ8R6cN2SU9bhV74kLKTDuMYqXcGxZxo6jZMU2H3C1M5A==", "c514a55b-ec64-49bc-bbc1-4f70edb87e29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9fbfd8-91d9-496a-af89-7b330c88d754", "AQAAAAIAAYagAAAAECCCCgzA6toBh8dZEJ/fnPYZTBUbtlDiudywPsUqCpUdCDpRD4y5tPT26pLOFA3qoQ==", "c24b9c7a-c9e7-4c62-a07b-7ae834310937" });

            migrationBuilder.InsertData(
                table: "CompanyManagers",
                columns: new[] { "Id", "Address", "BirthDate", "BirthPlace", "CompanyId", "Created", "Department", "Email", "Name", "Phone", "Photo", "PictureFile", "Profession", "SecondName", "SecondSurname", "Surname", "TC", "Updated", "WorkStartDate" },
                values: new object[,]
                {
                    { 1, "Ankara, Türkiye", new DateOnly(1985, 7, 15), "Ankara", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "ahmet.yilmaz@teknolojiyenilikcileri.com", "Ahmet", "+90 532 111 2233", null, null, "Mühendis", "Murat", "Kaya", "Yılmaz", "12345678901", null, new DateOnly(2010, 9, 1) },
                    { 2, "Tunceli, Türkiye", new DateOnly(1990, 4, 20), "İstanbul", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "elif.demir@rollinemuhendislik.com", "Elif", "+90 212 333 4455", null, null, "Dış Ticaret Sorumlusu", "Nur", "Yıldız", "Demir", "98765432109", null, new DateOnly(2015, 6, 15) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyManagers_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId");
        }
    }
}
