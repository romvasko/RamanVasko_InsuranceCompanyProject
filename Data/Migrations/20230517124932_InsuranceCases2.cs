using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class InsuranceCases2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCase_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceCase",
                table: "InsuranceCase");

            migrationBuilder.RenameTable(
                name: "InsuranceCase",
                newName: "InsuranceCases");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceCase_PoliciesOrderId",
                table: "InsuranceCases",
                newName: "IX_InsuranceCases_PoliciesOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceCases",
                table: "InsuranceCases",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuranceCases",
                table: "InsuranceCases");

            migrationBuilder.RenameTable(
                name: "InsuranceCases",
                newName: "InsuranceCase");

            migrationBuilder.RenameIndex(
                name: "IX_InsuranceCases_PoliciesOrderId",
                table: "InsuranceCase",
                newName: "IX_InsuranceCase_PoliciesOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuranceCase",
                table: "InsuranceCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCase_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCase",
                column: "PoliciesOrderId",
                principalTable: "PoliciesOrders",
                principalColumn: "Id");
        }
    }
}
