using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class BankPayment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "BankPaymentId",
                table: "CarPolicyOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPayment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesOrders_BankPaymentsId",
                table: "PoliciesOrders",
                column: "BankPaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPolicyOrder_BankPaymentId",
                table: "CarPolicyOrder",
                column: "BankPaymentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPolicyOrder_BankPayment_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_BankPayment_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropTable(
                name: "BankPayment");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesOrders_BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropIndex(
                name: "IX_CarPolicyOrder_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropColumn(
                name: "BankPaymentsId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "BankPaymentId",
                table: "CarPolicyOrder");
        }
    }
}
