using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personelrole1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 3 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07ed98a5-f169-4754-8424-a98a362d7b27", "AQAAAAIAAYagAAAAEHc0ljg+3o1hQKz2psi9yp3l4q/ZqaTHpQg486L3OqO8ngraGkGpNkG7NesPwzt+JA==", "c06598f2-dfff-418f-954d-5caaa0fd8769" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80e74596-294a-4183-9263-da969b330fc3", "AQAAAAIAAYagAAAAEJD5IYol1I7QZv+nUVf5/Zj6WuHMdoZmR+0Btsngo5I4FOP2jlr9WDKld6gvbdffoQ==", "d935ff2b-f242-4690-8fa9-235deacffa1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e90f814-ef3a-4017-8bee-a72e12978f75", "AQAAAAIAAYagAAAAEBAG9LitwsffRgPuZQAQd+i6PuwELUSQklyxJKWSEEs+u4KDMAxyVa6c/9nvMDS4GA==", "3027cfc9-3a49-4dd4-a1f1-d8a5fc126c0b" });
        }
    }
}
