using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PropNullYapma3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12aa7d49-a0f2-42a9-845f-f41001d7a0b1", "AQAAAAIAAYagAAAAEL3JoGTta6LAjO1RwyBz6MLpBjTOWeBRSgbAn2j80MIuWvIP91cQnoHiz0cspUkEig==", "8335d1ce-4e08-42e7-83f7-fae728c06b7b" });

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Profession",
                value: "Mühendis");

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Profession",
                value: "Dış Ticaret Sorumlusu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f7f885-22f5-4e82-8ef7-5111beda87b0", "AQAAAAIAAYagAAAAEDVAxcvHqUEs6AYDSu4Qrb6/ApRfMvCx7XP40C40J8CJrKP3uIYY7+MlMIPH+ZPZWw==", "bff7ff09-d247-4873-aca5-f736f8ac0887" });

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Profession",
                value: "Teknoloji Yenilikçileri A.Ş.");

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Profession",
                value: "Rolline Mühendislik Ltd.");
        }
    }
}
