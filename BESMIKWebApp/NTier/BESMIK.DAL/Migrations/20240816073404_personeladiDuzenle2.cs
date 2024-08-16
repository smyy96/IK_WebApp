using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personeladiDuzenle2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "075421ed-d117-4a1c-a0ec-99f376ff9dd4", "AQAAAAIAAYagAAAAEHQOeio74XgTJodGnNioyiByQVWxJJEehKZVujJwyVKxw2UCeJPTjp0de9Zr8Fb06g==", "b781a01d-1318-4081-878a-a7acf5df9e3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01528935-3bce-4d07-bf68-ab22e2e0f8be", "FADIME.GUNGORMEMIS@ROLLINEMUHENDISLIK.COM", "AQAAAAIAAYagAAAAEHU2WvOtyGK6JOcEsyRsR7xby5xo7VBkQsn5JePI472V3FRcWAmnvbZ+Obh7N7TQTQ==", "19e6ed4b-961e-4f4e-905a-7b176d9484df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21da62de-9904-4330-9f04-36cc9f0791d1", "kezban.gunyuzu@rollinemuhendislik.com", "KEZBAN.GUNYUZU@ROLLINEMUHENDISLIK.COM", "AQAAAAIAAYagAAAAEBKN2o4ncZp7JSBnvrDtqRpGTN4Wtx5Lkaq0vRXFtA6BDzU8QX5TCKSEVivJF5Kscw==", "373e407d-147f-4b26-996c-dd1158fc85ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4530cead-9081-4e5a-9cc3-12a728a765a3", "PERSONEL1.PERSONEL@BILGEADAM.COM", "AQAAAAIAAYagAAAAENHcdDG3bEzpZ7NvY79+1Uaesf0pdBCXtd0swpgyqIRNNfgKi9MmR6V/WYujCK3Dzg==", "e067a0b5-d616-4441-a021-133c24c00f7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff58159-b958-48c5-9eb6-b51ddf288a8e", "personel2.personel@bilgeadam.com", "PERSONEL2.PERSONEL@BILGEADAM.COM", "AQAAAAIAAYagAAAAEBM4Zm7rnNNK4UnkuYw4JB9krko8dgYjRecqw8Ha9mQrxqyQReUFj9aZoFch4tvTww==", "097eb731-b93b-43e7-bca3-c9016796e7fd" });
        }
    }
}
