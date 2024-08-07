using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CompanyManAddress1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fc1fabc-cb74-4d12-b407-8bfdac539629", "AQAAAAIAAYagAAAAEBW8+IiPNgdkQrn+SAOiMLv+qZITdDnRdGcoinCKv2S4BsjF/+gsknQKX/ko0hh3qQ==", "90eee83c-7959-4a82-b34a-6221c80a31e1" });

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Ankara, Türkiye");

            migrationBuilder.UpdateData(
                table: "CompanyManagers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Tunceli, Türkiye");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CompanyManagers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adbc5dd7-3e0b-4a46-8781-47e933eb842a", "AQAAAAIAAYagAAAAEKyw+qZ/l0bUuoqVMCj3NH0GDHg+SDjD9AYJRLUTV79zb5EFpwyFUYnksSzvcEH+4A==", "f281a7a4-e9f5-4e87-975f-1770f52907cb" });
        }
    }
}
