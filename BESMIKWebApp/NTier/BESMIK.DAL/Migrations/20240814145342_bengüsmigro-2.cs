using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class bengüsmigro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PermissionResponseDate",
                table: "Permissions",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PermissionRequestDate",
                table: "Permissions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PermissionResponseDate",
                table: "Permissions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PermissionRequestDate",
                table: "Permissions",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ab6d86-6097-40d1-a850-5bb5dd39296a", "AQAAAAIAAYagAAAAEJCko94mt0O2OTb6fkLNnkZ4VkaQ7mtO2DLWO+0x0xpMDuCNV9JhaFXooW+LuuayWA==", "dea8db82-eac0-4f2f-947b-6c6e18ddbcd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6da7dc45-e2fc-4944-8ac4-be0911a88d5f", "AQAAAAIAAYagAAAAEOEGAqhifjrfdp9bDjyFYipciKgyRwDd52TRhVRBCLkkMjX3CYyvSQxl7AAbs6g4Jg==", "b768b332-be31-4131-b4e3-370503c4262a" });
        }
    }
}
