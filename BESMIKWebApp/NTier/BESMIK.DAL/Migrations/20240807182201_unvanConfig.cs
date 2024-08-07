using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class unvanConfig : Migration
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
                values: new object[] { "6aba4785-ce52-442c-a838-118e67aba4ea", "AQAAAAIAAYagAAAAEGCQ53oawjrwtYJnBehHsCtXsIH+Mf5Bu5EtZdYwYEuGa6tSFsd5/CC73w9H0+sG/g==", "3d86eeaf-c724-41b8-9a97-f3ac33b0636c" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TitleName" },
                values: new object[] { "Teknoloji Yenilikçileri", "A.Ş." });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "TitleName" },
                values: new object[] { "Rolline Mühendislik", " Ltd." });

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

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TitleName" },
                values: new object[] { "Teknoloji Yenilikçileri A.Ş.", "Teknoloji Yenilikçileri" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "TitleName" },
                values: new object[] { "Rolline Mühendislik Ltd.", "Rolline Mühendislik" });
        }
    }
}
