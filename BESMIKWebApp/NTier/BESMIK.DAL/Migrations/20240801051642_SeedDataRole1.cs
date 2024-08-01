using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataRole1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Site Yöneticisi", "SITE YONETICISI" },
                    { 2, null, "Şirket Yöneticisi", "SIRKET YONETICISI" },
                    { 3, null, "Personel", "PERSONEL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a46ec36a-68e6-4a7c-aeb7-fe7578a9dec0", "AQAAAAIAAYagAAAAEO6rzkrjvwqkj5FjOAMTm7CMi6kMtqXFOug/aBCVJcm9T7T9zeLmvsNOyPSwX1Xb9g==", "30cb386c-5613-4893-bca6-35eeaffdd553" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f69af096-8130-4ad0-a1f5-c8f20324cfd5", "AQAAAAIAAYagAAAAEBojBYQTYOzaAT6sXHelbzQwWfhfZOIUzGK4Fn/LxDiNdjg0SygJ7Y9TXQ/NpL4iAA==", "742e0232-ab95-445e-90d9-6293e11ec0be" });
        }
    }
}
