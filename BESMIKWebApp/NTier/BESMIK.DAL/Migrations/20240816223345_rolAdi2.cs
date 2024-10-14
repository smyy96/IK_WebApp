using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class rolAdi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: "SIRKET YONETICISI");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: "ŞİRKET YÖNETİCİSİ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dbdb614-5d5a-4c29-a1b0-8cce19daccfe", "AQAAAAIAAYagAAAAEEzQIAAuc3Qpxay3UER1i5kFk84bk4MkOPjxwSxa9Gp9/G6z4k5Wnv76/XEfH+cnYg==", "ff7305c2-a3bb-46fd-a1c6-ed80344ad4ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc352b7-46c3-4578-a7a6-f1a39dbe7cfb", "AQAAAAIAAYagAAAAEEJpgHA9NS5KrEKWOmd08aOSZoPlj0FeCie+9bz49e5WFMG6Y1HSzXLv9I69hrYsUQ==", "13ade061-d3f4-46ee-b463-970a1fe30fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ded716b6-66ce-4246-9d9f-addfdcad6d87", "AQAAAAIAAYagAAAAEPSnkvHf74TyxQPvT48Cv+lQWO4VYUk5j3I/nw6h4i8aCFQU9o4adCGM0hhQiPbn/g==", "a717e0b8-f075-43a1-9e38-8a8f6d3bb692" });
        }
    }
}
