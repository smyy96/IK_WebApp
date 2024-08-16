using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class rolAdi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Site Yoneticisi");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sirket Yoneticisi");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86be6d25-09b8-4589-84f2-bd01addd43bd", "AQAAAAIAAYagAAAAED2KHsN3nv2hEsTZjxI/zSua4hWfGSH3slwB8eLSt5kFVQRsxkCEBqAD9BosKG2V+g==", "d07a451a-151f-457c-90e5-6ab39048d784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a2ebd25-d259-4890-bbf6-836c29d0ea05", "AQAAAAIAAYagAAAAEPW5evq7PTrDF7doXizOdiQ8R6cN2SU9bhV74kLKTDuMYqXcGxZxo6jZMU2H3C1M5A==", "c514a55b-ec64-49bc-bbc1-4f70edb87e29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9fbfd8-91d9-496a-af89-7b330c88d754", "AQAAAAIAAYagAAAAECCCCgzA6toBh8dZEJ/fnPYZTBUbtlDiudywPsUqCpUdCDpRD4y5tPT26pLOFA3qoQ==", "c24b9c7a-c9e7-4c62-a07b-7ae834310937" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Site Yöneticisi");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Şirket Yöneticisi");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b8b6d23-5434-43c4-809c-344ba7a21e04", "AQAAAAIAAYagAAAAEBtSceDfmzdao5Q+qiL5vlYtuREUqU84VB/CCZ18sdD7Qf4E6w0eJpXaJPQrG3AjEQ==", "b03d14fc-0e4f-4a04-b13e-b585804f82ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81a7c8f4-de23-4aff-8b1a-6019995798ad", "AQAAAAIAAYagAAAAEOk48bt9jzKxA44TQEbSTpd5RwHVMYv/s+F9Au7sSXWc6X8r1qZ96CrwI0MU+FZxTw==", "efa3fd41-7ec5-4a19-999d-c9fa4c922e7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32bde174-7965-4ecd-97ff-89b4883d09cc", "AQAAAAIAAYagAAAAECyMtBeo7KjXTvFpkUqa5qgWg6qvKJgwiwy3o7IYKJr0dnZmGVrKeedjkVWWjRpccA==", "66cba2e0-8756-434b-97eb-79ea0a353c46" });
        }
    }
}
