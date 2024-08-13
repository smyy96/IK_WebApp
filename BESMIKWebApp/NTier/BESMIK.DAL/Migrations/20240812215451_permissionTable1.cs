using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class permissionTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PermissionEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OffDaysNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    PermissionStatus = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AppUserId",
                table: "Permissions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Permissions");

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
                values: new object[] { "6aba4785-ce52-442c-a838-118e67aba4ea", "AQAAAAIAAYagAAAAEGCQ53oawjrwtYJnBehHsCtXsIH+Mf5Bu5EtZdYwYEuGa6tSFsd5/CC73w9H0+sG/g==", "3d86eeaf-c724-41b8-9a97-f3ac33b0636c" });
        }
    }
}
