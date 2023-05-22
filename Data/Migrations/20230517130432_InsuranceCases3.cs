using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class InsuranceCases3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases");

            migrationBuilder.DropColumn(
                name: "PoliceId",
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "InsuranceCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases",
                column: "PoliciesOrderId",
                principalTable: "PoliciesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InsuranceCases");

            migrationBuilder.AlterColumn<int>(
                name: "PoliciesOrderId",
                table: "InsuranceCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PoliceId",
                table: "InsuranceCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceCases_PoliciesOrders_PoliciesOrderId",
                table: "InsuranceCases",
                column: "PoliciesOrderId",
                principalTable: "PoliciesOrders",
                principalColumn: "Id");
        }
    }
}
