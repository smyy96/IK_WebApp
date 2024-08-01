using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class pictureFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PictureFile",
                table: "CompanyManagers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureFile",
                table: "Companies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a88f56-2aad-47bb-8c6e-6a62eed1717c", "AQAAAAIAAYagAAAAECISDkM0qUYPjpqE23EJ3k+tXagGhw+PGBTcYHUsm68kBfsBz93R5h22h1YCfcySGg==", "c5b35766-793e-432b-8608-b28b84e9174c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureFile",
                table: "CompanyManagers");

            migrationBuilder.DropColumn(
                name: "PictureFile",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56f4b626-ffa3-446b-8ced-ef5b050579e6", "AQAAAAIAAYagAAAAEN7G78mv4PX6+FXkHaFVK5H6lbH1a68NUD3zh5kMqM1ublUWvQAjgUH0tyAW0275fw==", "3b0dbda9-151e-4e54-8a7f-f8072e6ae416" });
        }
    }
}
