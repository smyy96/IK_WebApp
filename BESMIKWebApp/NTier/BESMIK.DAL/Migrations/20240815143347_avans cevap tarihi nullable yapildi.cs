using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class avanscevaptarihinullableyapildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "AdvanceResponseDate",
                table: "Advances",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "143c0491-9a26-4808-93e5-55eec4b4e401", "AQAAAAIAAYagAAAAEO4nVaTTHzsRzcGnAqEQ35Wk9AaPcprYWrnIwFlYLlYuh4sqLSTdrouq9TdEz2XiiQ==", "6ba1fc8f-8c59-4728-9b21-0d8554bc031d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a86f0c-937c-411c-b5e5-1008670abac1", "AQAAAAIAAYagAAAAEMJHujsB+gbHcqnLolU5eInMkCO6Sux10wGRFtFIOi5H8eYmVb64TXagxeVwvmCT5Q==", "0e2d442e-fc67-4a10-b955-2674b763f2d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf48b0f-13b2-4062-ae4f-f62fa5b699d3", "AQAAAAIAAYagAAAAELYfgE3gQl5T7Lx55/A1mRKOH4Lfgtxm0x/3CXtGnGziXXZgHqALlA9PAfrjtQcLIQ==", "70f40e32-f325-4931-9a11-2ec67e2615c3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "AdvanceResponseDate",
                table: "Advances",
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
                values: new object[] { "3d6f58f6-219a-407b-9cbd-71d5f3285ede", "AQAAAAIAAYagAAAAEJowJ4bs10Z3tx+jDke/fVOgMj2tC2s1rZIOZ9qh2BDj/RbOnf7aAawzsamuqFVrIg==", "d9737378-9ebb-4c92-8c40-eddfb3abe6d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25e0f12e-f7f7-43da-bb52-4c4858f523c6", "AQAAAAIAAYagAAAAENIsQJMvMW4Zq+3Rb/tFt389U9FoZ4/GTM6oQBqlsZBN6wO4BbX2DCiZMfqorA8yaw==", "7aa2e035-5bb2-4263-8a28-4a190d599025" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1820591-8fa4-4f5c-82e7-9c624926eb36", "AQAAAAIAAYagAAAAELvydV+YMib16j4BW846N3YpglK+SCE8oqaaNn0Vm0wlSlybHUUbo8YIy66T48pbdg==", "8634969f-40b5-4e55-a52a-6c38c2fdf105" });
        }
    }
}
