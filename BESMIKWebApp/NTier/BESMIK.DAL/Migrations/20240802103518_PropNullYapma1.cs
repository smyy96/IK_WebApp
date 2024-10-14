using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PropNullYapma1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77503549-3f8f-4b80-aba9-acfb796ca963", "AQAAAAIAAYagAAAAEJaePhjBjCPBl/g7jCzGXa3i+zY+ttsgxTs5cnT0Wxiv2g1SlIgG59MY3AYDqJnYkQ==", "746e0c06-7d1b-4afb-bd0c-093873210286" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6048a601-3c00-4ab7-acf0-c2ad5406907b", "AQAAAAIAAYagAAAAEOSmqYJTcEAvGSbAC/juKaLkXt2mrFF5DcaJFh36VlpY0nWNlQaWtGIL19eImPvzcQ==", "c6c7cea5-048d-4beb-bdc3-72eb1a362926" });
        }
    }
}
