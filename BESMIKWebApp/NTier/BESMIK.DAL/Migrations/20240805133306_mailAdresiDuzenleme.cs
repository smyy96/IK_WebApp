using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mailAdresiDuzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80224fa8-cf0e-467f-b2a5-fe7910c5f3b5", "AQAAAAIAAYagAAAAEDDZEmNXy3uAmfFTL8k0Hn1Rk3d5Q5DuSxxwsTSF0DnozLy4yl/vaSW+3tHxMMoupA==", "9a8bb739-e02d-4114-9ff6-fe2c8e4023b3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12aa7d49-a0f2-42a9-845f-f41001d7a0b1", "AQAAAAIAAYagAAAAEL3JoGTta6LAjO1RwyBz6MLpBjTOWeBRSgbAn2j80MIuWvIP91cQnoHiz0cspUkEig==", "8335d1ce-4e08-42e7-83f7-fae728c06b7b" });
        }
    }
}
