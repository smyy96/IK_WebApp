using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AppUserMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f537b1-ce03-4837-96df-a0dc15997741", "site.yoneticisi@bilgeadam.com", "SITE.YONETICISI@BILGEADAM.COM", "AQAAAAIAAYagAAAAEJLo/bbu+zfMzWK/1/ziQNFeKyUlOTC8UTD2ZQkMD8HJj20TA8KjyEi4WLb3OCh+dw==", "d765a13a-fd5a-4326-8a2a-7d548b231400" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80224fa8-cf0e-467f-b2a5-fe7910c5f3b5", "siteyoneticisi@mail.com", "SITEYONETICISI@MAIL.COM", "AQAAAAIAAYagAAAAEDDZEmNXy3uAmfFTL8k0Hn1Rk3d5Q5DuSxxwsTSF0DnozLy4yl/vaSW+3tHxMMoupA==", "9a8bb739-e02d-4114-9ff6-fe2c8e4023b3" });
        }
    }
}
