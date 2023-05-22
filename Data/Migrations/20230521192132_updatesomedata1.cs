using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class updatesomedata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PoliciesOrders",
                columns: new[] { "Id", "BankPaymentsId", "Cost", "PaymentId", "PoliciesId", "PoliciesOrderDateTime", "PoliciesStatusId", "UserId" },
                values: new object[,]
                {
                    { 1000, null, 48000m, 0, 2, new DateTime(2020, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User1@user.com" },
                    { 1001, null, 62000m, 0, 2, new DateTime(2021, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User2@user.com" },
                    { 1002, null, 150m, 0, 2, new DateTime(2022, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User3@user.com" },
                    { 1003, null, 7894m, 0, 1, new DateTime(2021, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User4@user.com" },
                    { 1004, null, 5555m, 0, 1, new DateTime(2023, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User5@user.com" },
                    { 1005, null, 7777m, 0, 2, new DateTime(2023, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User4@user.com" },
                    { 1006, null, 6548m, 0, 2, new DateTime(2020, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User3@user.com" },
                    { 1007, null, 1254m, 0, 1, new DateTime(2020, 5, 16, 5, 50, 6, 0, DateTimeKind.Unspecified), 4, "User2@user.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "PoliciesOrders",
                keyColumn: "Id",
                keyValue: 1007);
        }
    }
}
