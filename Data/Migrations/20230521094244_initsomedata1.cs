using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class initsomedata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "BaseCost", "PoliciesDescription", "PoliciesName", "PoliciesTypeId" },
                values: new object[] { 2, 1000m, "Страхование вкладов", "Вклады", 2 });

            migrationBuilder.InsertData(
                table: "PoliciesStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "InProced" },
                    { 2, "Accepted" },
                    { 3, "Declined" },
                    { 4, "Paid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PoliciesStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PoliciesStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PoliciesStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PoliciesStatuses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
