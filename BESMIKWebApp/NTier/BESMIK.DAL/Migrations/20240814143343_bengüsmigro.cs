using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class bengüsmigro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "e77e5149-2730-43f0-a332-10d9a6932b92", "AQAAAAIAAYagAAAAEE2AxJBQ7CIJ0WIG7azKfqHly2NhcwuD3prpMorBegOZkDiMsODL1Kcq78ZkjDPp3A==", "1b1154db-a860-455b-bfd6-7d1e8a81b601" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71336bac-5fca-40d3-bf58-291629bf3d96", "AQAAAAIAAYagAAAAENvhNgy7/s6CAbyQU8YakHlrNenE0JKz7qOYHuHuviYFWtGLqjAfPTurdNScpiGrvQ==", "89b9e358-17b7-4d33-8012-5265c2e5011c" });
        }
    }
}
