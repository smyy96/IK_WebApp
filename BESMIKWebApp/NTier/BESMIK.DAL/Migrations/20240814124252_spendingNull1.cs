using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class spendingNull1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "SpendingResponseDate",
                table: "Spendings",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "SpendingResponseDate",
                table: "Spendings",
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
                values: new object[] { "3d037720-30e0-40de-936b-c5a3f24a29b2", "AQAAAAIAAYagAAAAEDwqC1UgPb/nOHB0ShfNekK/+ngH3Ac6Z7Idz6fZAwCMgECEZf6NSYW54c8MAcfdqA==", "8557ef84-5b2e-4415-92a0-6cf243b6406b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b26c48d0-a287-4130-a8fc-366eb518db3f", "AQAAAAIAAYagAAAAEJm/z4mC/CAYK9PmCf3Lo1BnDJYh7HLzjZ6U3KtwqNHa4cJ55uTqdYlSQcNfJbxBfw==", "80a40e7e-f53c-4824-981e-46ab7a426373" });
        }
    }
}
