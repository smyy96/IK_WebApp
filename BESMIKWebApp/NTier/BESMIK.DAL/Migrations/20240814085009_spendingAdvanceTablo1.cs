using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class spendingAdvanceTablo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "PermissionRequestDate",
                table: "Permissions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "PermissionResponseDate",
                table: "Permissions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "Advances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceRequestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    AdvanceResponseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvanceType = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advances_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spendings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpendingType = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<float>(type: "real", nullable: false),
                    SpendingCurrency = table.Column<int>(type: "int", nullable: false),
                    SpendingStatus = table.Column<int>(type: "int", nullable: false),
                    SpendingRequestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SpendingResponseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SpendingFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spendings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spendings_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f22c2362-b641-4879-b55d-19c588771aee", "AQAAAAIAAYagAAAAEARRsQB8Q8yQRTcy1kpuPIG8QEE8V8qGGiuQqQmx6i8JTAXpybG6AP1XUDPXTJcCvA==", "74f19a10-6601-4fd8-a347-0a734bd17303" });

            migrationBuilder.CreateIndex(
                name: "IX_Advances_AppUserId",
                table: "Advances",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_AppUserId",
                table: "Spendings",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advances");

            migrationBuilder.DropTable(
                name: "Spendings");

            migrationBuilder.DropColumn(
                name: "PermissionRequestDate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionResponseDate",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbff1037-4f4b-4b96-b0b8-ed9351e3708f", "AQAAAAIAAYagAAAAEBRWOQxu4+WB68BrdyWACr7bLGmZyABMf7yDPMWOKJCnabZJPk3k5F0AcPNrX9h1jg==", "8f1ceaef-fa0e-49af-8fda-971641a5f13c" });
        }
    }
}
