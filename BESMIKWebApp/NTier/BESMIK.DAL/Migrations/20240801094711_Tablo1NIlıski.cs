using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Tablo1NIlıski : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyManagers_CompanyManagerId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyManagerId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyManagerId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "CompanyManagers",
                newName: "CompanyName");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CompanyManagers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56f4b626-ffa3-446b-8ced-ef5b050579e6", "AQAAAAIAAYagAAAAEN7G78mv4PX6+FXkHaFVK5H6lbH1a68NUD3zh5kMqM1ublUWvQAjgUH0tyAW0275fw==", "3b0dbda9-151e-4e54-8a7f-f8072e6ae416" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyManagers_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyManagers_CompanyId",
                table: "CompanyManagers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompanyManagers");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "CompanyManagers",
                newName: "Company");

            migrationBuilder.AddColumn<int>(
                name: "CompanyManagerId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83287062-2cfa-43a4-86fc-eeba400a7f9d", "AQAAAAIAAYagAAAAELNrSj2YyAHyroBsozp/SFGVxzZSpM0c3aSsWNaNP997qBww+HWQ0/N9/XW6dArDbA==", "6b5190e6-c76f-491b-b83c-f6d2b9495668" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyManagerId",
                table: "Companies",
                column: "CompanyManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyManagers_CompanyManagerId",
                table: "Companies",
                column: "CompanyManagerId",
                principalTable: "CompanyManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
