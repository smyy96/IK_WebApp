using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personeladiDuzenle1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a34c306a-8b61-49e8-a057-c7ee31624fcc", "AQAAAAIAAYagAAAAEEQlPyXIdUPApDg4jhjSjBdm9t2h63iMY4HLQ2amvRukLCi+5t0XYHuuLmMQi8zZDg==", "a8bc125a-f75f-45c7-b4d3-7cd35f75176f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4530cead-9081-4e5a-9cc3-12a728a765a3", "fadime.gungormemis@rollinemuhendislik.com", "AQAAAAIAAYagAAAAENHcdDG3bEzpZ7NvY79+1Uaesf0pdBCXtd0swpgyqIRNNfgKi9MmR6V/WYujCK3Dzg==", "e067a0b5-d616-4441-a021-133c24c00f7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff58159-b958-48c5-9eb6-b51ddf288a8e", "AQAAAAIAAYagAAAAEBM4Zm7rnNNK4UnkuYw4JB9krko8dgYjRecqw8Ha9mQrxqyQReUFj9aZoFch4tvTww==", "097eb731-b93b-43e7-bca3-c9016796e7fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a86f0c-937c-411c-b5e5-1008670abac1", "personel1.personel@bilgeadam.com", "AQAAAAIAAYagAAAAEMJHujsB+gbHcqnLolU5eInMkCO6Sux10wGRFtFIOi5H8eYmVb64TXagxeVwvmCT5Q==", "0e2d442e-fc67-4a10-b955-2674b763f2d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cf48b0f-13b2-4062-ae4f-f62fa5b699d3", "AQAAAAIAAYagAAAAELYfgE3gQl5T7Lx55/A1mRKOH4Lfgtxm0x/3CXtGnGziXXZgHqALlA9PAfrjtQcLIQ==", "70f40e32-f325-4931-9a11-2ec67e2615c3" });
        }
    }
}
