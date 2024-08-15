using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personelAdi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Job", "Name", "PasswordHash", "Photo", "SecurityStamp", "Surname" },
                values: new object[] { "41e141c9-bd89-4af2-970d-1af6197a4cb2", "Bilgisayar Mühendisi", "Fadime", "AQAAAAIAAYagAAAAEDE7d46ctHwTMRgRpBggEEZU7k/0WQfAjJ65uu8W/1pAAKXOBj5FUhm9k4OxwXeG7Q==", "AcKedi.jpg", "1a0eeb2c-71a9-4e7d-b358-bcaa6867a84f", "Güngörmemiş" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e609039d-ad05-4dfe-acbb-e473b5eb3eab", "AQAAAAIAAYagAAAAEON0C6dJfb/6YJw+zXlQ79FPGi+/yxfZPcUnbkynHsx5S5PLPmHwjjzMRgKLvuyNzA==", "6b1802ec-bb9a-4d38-a231-665e9ef18356" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Job", "Name", "PasswordHash", "Photo", "SecurityStamp", "Surname" },
                values: new object[] { "df5d10e6-9ff3-48ad-94d4-bb19b4f145c9", "İK", "PersonelAdı 1", "AQAAAAIAAYagAAAAEFEGqg/KuOaO+U8GM+vcs8JgD8R8ogmceJGB+LN4MhNDRFnrnl4pPcDZiJiAphPntA==", null, "a12592e1-a917-4ebc-bad8-1f0e77de4008", "PersonelSoyadı 1" });
        }
    }
}
