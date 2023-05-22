using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class BankPayment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPolicyOrder_BankPayment_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_BankPayment_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPayment",
                table: "BankPayment");

            migrationBuilder.RenameTable(
                name: "BankPayment",
                newName: "BankPayments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPayments",
                table: "BankPayments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPolicyOrder_BankPayments_BankPaymentId",
                table: "CarPolicyOrder",
                column: "BankPaymentId",
                principalTable: "BankPayments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_BankPayments_BankPaymentsId",
                table: "PoliciesOrders",
                column: "BankPaymentsId",
                principalTable: "BankPayments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPolicyOrder_BankPayments_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_BankPayments_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPayments",
                table: "BankPayments");

            migrationBuilder.RenameTable(
                name: "BankPayments",
                newName: "BankPayment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPayment",
                table: "BankPayment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPolicyOrder_BankPayment_BankPaymentId",
                table: "CarPolicyOrder",
                column: "BankPaymentId",
                principalTable: "BankPayment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_BankPayment_BankPaymentsId",
                table: "PoliciesOrders",
                column: "BankPaymentsId",
                principalTable: "BankPayment",
                principalColumn: "Id");
        }
    }
}
