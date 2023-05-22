using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class removePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_BankPayments_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesOrders_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PoliciesOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankPaymentsId",
                table: "PoliciesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PoliciesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesOrders_BankPaymentsId",
                table: "PoliciesOrders",
                column: "BankPaymentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_BankPayments_BankPaymentsId",
                table: "PoliciesOrders",
                column: "BankPaymentsId",
                principalTable: "BankPayments",
                principalColumn: "Id");
        }
    }
}
