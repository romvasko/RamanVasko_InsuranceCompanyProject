using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class bankpaymentpolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPolicyOrder_BankPayments_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropIndex(
                name: "IX_CarPolicyOrder_BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.DropColumn(
                name: "BankPaymentId",
                table: "CarPolicyOrder");

            migrationBuilder.CreateTable(
                name: "bankPaymentPolicyOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliciesOrderId = table.Column<int>(type: "int", nullable: false),
                    BankPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankPaymentPolicyOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bankPaymentPolicyOrders_BankPayments_BankPaymentId",
                        column: x => x.BankPaymentId,
                        principalTable: "BankPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bankPaymentPolicyOrders_PoliciesOrders_PoliciesOrderId",
                        column: x => x.PoliciesOrderId,
                        principalTable: "PoliciesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bankPaymentPolicyOrders_BankPaymentId",
                table: "bankPaymentPolicyOrders",
                column: "BankPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_bankPaymentPolicyOrders_PoliciesOrderId",
                table: "bankPaymentPolicyOrders",
                column: "PoliciesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankPaymentPolicyOrders");

            migrationBuilder.AddColumn<int>(
                name: "BankPaymentId",
                table: "CarPolicyOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarPolicyOrder_BankPaymentId",
                table: "CarPolicyOrder",
                column: "BankPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPolicyOrder_BankPayments_BankPaymentId",
                table: "CarPolicyOrder",
                column: "BankPaymentId",
                principalTable: "BankPayments",
                principalColumn: "Id");
        }
    }
}
