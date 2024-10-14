using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PropNullYapma2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "CompanyManagers",
                newName: "Profession");

            migrationBuilder.AlterColumn<string>(
                name: "SecondSurname",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f7f885-22f5-4e82-8ef7-5111beda87b0", "AQAAAAIAAYagAAAAEDVAxcvHqUEs6AYDSu4Qrb6/ApRfMvCx7XP40C40J8CJrKP3uIYY7+MlMIPH+ZPZWw==", "bff7ff09-d247-4873-aca5-f736f8ac0887" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "CompanyManagers",
                newName: "CompanyName");

            migrationBuilder.AlterColumn<string>(
                name: "SecondSurname",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77503549-3f8f-4b80-aba9-acfb796ca963", "AQAAAAIAAYagAAAAEJaePhjBjCPBl/g7jCzGXa3i+zY+ttsgxTs5cnT0Wxiv2g1SlIgG59MY3AYDqJnYkQ==", "746e0c06-7d1b-4afb-bd0c-093873210286" });
        }
    }
}
