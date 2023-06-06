using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class translate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PoliciesDescription", "PoliciesName" },
                values: new object[] { "Car insurance", "Car insurance" });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PoliciesDescription", "PoliciesName" },
                values: new object[] { "Deposits insurance", "Deposits insurance" });

            migrationBuilder.UpdateData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PoliciesTypeName",
                value: "Private");

            migrationBuilder.UpdateData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PoliciesTypeName",
                value: "Corporate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PoliciesDescription", "PoliciesName" },
                values: new object[] { "Страхование автомобилей", "Автомобильное" });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PoliciesDescription", "PoliciesName" },
                values: new object[] { "Страхование вкладов", "Вклады" });

            migrationBuilder.UpdateData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PoliciesTypeName",
                value: "Частные");

            migrationBuilder.UpdateData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PoliciesTypeName",
                value: "Корпоративные");
        }
    }
}
