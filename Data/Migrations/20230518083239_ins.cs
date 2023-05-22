using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class ins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases");

            migrationBuilder.AlterColumn<int>(
                name: "PoliciesOrderId",
                table: "InsuranceCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases",
                column: "PoliciesOrderId",
                principalTable: "PoliciesOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases");

            migrationBuilder.AlterColumn<int>(
                name: "PoliciesOrderId",
                table: "InsuranceCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases",
                column: "PoliciesOrderId",
                principalTable: "PoliciesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
