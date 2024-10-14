using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AppUserMail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adbc5dd7-3e0b-4a46-8781-47e933eb842a", "site.yoneticisi@bilgeadam.com", "SITE.YONETICISI@BILGEADAM.COM", "AQAAAAIAAYagAAAAEKyw+qZ/l0bUuoqVMCj3NH0GDHg+SDjD9AYJRLUTV79zb5EFpwyFUYnksSzvcEH+4A==", "f281a7a4-e9f5-4e87-975f-1770f52907cb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f537b1-ce03-4837-96df-a0dc15997741", "siteyoneticisi@gmail.com", "SITEYONETICISI@GMAIL.COM", "AQAAAAIAAYagAAAAEJLo/bbu+zfMzWK/1/ziQNFeKyUlOTC8UTD2ZQkMD8HJj20TA8KjyEi4WLb3OCh+dw==", "d765a13a-fd5a-4326-8a2a-7d548b231400" });
        }
    }
}
