using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class permissionTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbff1037-4f4b-4b96-b0b8-ed9351e3708f", "AQAAAAIAAYagAAAAEBRWOQxu4+WB68BrdyWACr7bLGmZyABMf7yDPMWOKJCnabZJPk3k5F0AcPNrX9h1jg==", "8f1ceaef-fa0e-49af-8fda-971641a5f13c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "2ac3a609-3ae9-426e-b270-4d6f5cc8d492", "AQAAAAIAAYagAAAAEBWD2yGs+AjC8PaqhcTsOGMTEAmw3S7WYSqNCs30r7xtyKbTmZzU7MuEyg8xYFMqvQ==", "595702e8-136e-4a48-af1c-3fc472f5f01c" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
