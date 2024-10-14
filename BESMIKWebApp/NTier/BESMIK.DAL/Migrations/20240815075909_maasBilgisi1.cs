using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class maasBilgisi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Wage",
                table: "AspNetUsers",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Wage" },
                values: new object[] { "e609039d-ad05-4dfe-acbb-e473b5eb3eab", "AQAAAAIAAYagAAAAEON0C6dJfb/6YJw+zXlQ79FPGi+/yxfZPcUnbkynHsx5S5PLPmHwjjzMRgKLvuyNzA==", "6b1802ec-bb9a-4d38-a231-665e9ef18356", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Wage" },
                values: new object[] { "df5d10e6-9ff3-48ad-94d4-bb19b4f145c9", "AQAAAAIAAYagAAAAEFEGqg/KuOaO+U8GM+vcs8JgD8R8ogmceJGB+LN4MhNDRFnrnl4pPcDZiJiAphPntA==", "a12592e1-a917-4ebc-bad8-1f0e77de4008", 150000f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wage",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e112502c-3300-4c57-92a0-bc9aa3fb9365", "AQAAAAIAAYagAAAAEN2DRt5J2eyFQQpuFQdmkgiWUjj2uLp5tI8F8Vtqlcpa4aBjIHBS5XYZQtTsP9A0lg==", "bb8c998f-d21b-4973-836f-01267025cbe3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18c613d8-523c-4849-ae7d-ef73e7f11947", "AQAAAAIAAYagAAAAEEtfedFfv5WP6Da6vK1y2s3w2vN0xhG6sW1ciVYljDV+hxZcvw8iCuSgPQgDZ6TH+g==", "2c7776e1-704c-43f5-bf5a-5406404c0824" });
        }
    }
}
