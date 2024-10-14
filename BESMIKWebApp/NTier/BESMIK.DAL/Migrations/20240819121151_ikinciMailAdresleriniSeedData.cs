using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BESMIK.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ikinciMailAdresleriniSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "7e412bb7-f452-40ae-a8dd-1d269c5c56e6", "AQAAAAIAAYagAAAAEJ8N/OJ7V91zkcSUwYUDGDEp9YH/ckbwkE+jH+k9OFu5ttFCkc2v5s0WNio8AmyxXg==", "siteyoneticisiyimben@gmail.com", "998eca70-d49f-4c4b-9ba9-416434f28455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "651a339d-6dfb-4f62-921b-013bac10f972", "AQAAAAIAAYagAAAAEKF1VmEnBfIvUT+bXt6wR7hL+l0OJ3s9UYTZlrz3BLgrfr7sM3Nupzz4RxZM6gFu9g==", "fadimegungormemis@gmail.com", "7b3b6a14-216a-472a-bc05-301713c0a22e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "5c7a32fd-4485-4625-851c-6dfd43cf01bb", "AQAAAAIAAYagAAAAELhZfq54mXptqGlvkXHNUT3/zwz60vuMIIl/8YgBNNR5CAY5sHCurFgip0QC13Q45w==", "kezbangunyuzu@gmail.com", "aeab4f1c-7bdf-493b-abcc-cf98739012e2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "323147d1-b0ac-4e4e-809e-f45e47491197", "AQAAAAIAAYagAAAAEOlF+ZdD2JoNhqWa2M2sxxnluaBrJym8EnCoF+rTUuhIURAI2hFtDLqa6ZvovR02lQ==", null, "37461e03-e5cd-4f5d-965c-b5d0670f1969" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "df377f4d-b536-4aeb-9a46-5e6961e22982", "AQAAAAIAAYagAAAAEDCoc6oEpzol4mY1KVr6aY6BCHoYyfqD4J5Y3yuxqLH2C3lMYEIlihfqlXPh26LIww==", null, "d0da89bc-ec2c-4004-adba-0b5b6261c5af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PersonalEmail", "SecurityStamp" },
                values: new object[] { "7f657a8b-da63-4c9c-b48d-a228bad49a6e", "AQAAAAIAAYagAAAAEAShjV5jYYQv40D2JjnoEIC6i4WWPYO7Kgdf/OquYvMpUVAgU2x4AEKcoT93RXXifQ==", null, "dd88b877-fc6d-4217-ad74-565544827a08" });
        }
    }
}
