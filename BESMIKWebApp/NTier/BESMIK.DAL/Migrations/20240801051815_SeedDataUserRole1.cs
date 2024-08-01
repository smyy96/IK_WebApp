using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUserRole1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83287062-2cfa-43a4-86fc-eeba400a7f9d", "AQAAAAIAAYagAAAAELNrSj2YyAHyroBsozp/SFGVxzZSpM0c3aSsWNaNP997qBww+HWQ0/N9/XW6dArDbA==", "6b5190e6-c76f-491b-b83c-f6d2b9495668" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a46ec36a-68e6-4a7c-aeb7-fe7578a9dec0", "AQAAAAIAAYagAAAAEO6rzkrjvwqkj5FjOAMTm7CMi6kMtqXFOug/aBCVJcm9T7T9zeLmvsNOyPSwX1Xb9g==", "30cb386c-5613-4893-bca6-35eeaffdd553" });
        }
    }
}
