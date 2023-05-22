using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class initsomedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PoliciesTypes",
                columns: new[] { "Id", "PoliciesTypeName" },
                values: new object[] { 1, "Частные" });

            migrationBuilder.InsertData(
                table: "PoliciesTypes",
                columns: new[] { "Id", "PoliciesTypeName" },
                values: new object[] { 2, "Корпоративные" });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "BaseCost", "PoliciesDescription", "PoliciesName", "PoliciesTypeId" },
                values: new object[] { 1, 1000m, "Страхование автомобилей", "Автомобильное", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PoliciesTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
