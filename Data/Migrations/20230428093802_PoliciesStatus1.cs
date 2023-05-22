using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class PoliciesStatus1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PoliciesOrders");

            migrationBuilder.AlterColumn<int>(
                name: "PoliciesStatusId",
                table: "PoliciesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders",
                column: "PoliciesStatusId",
                principalTable: "PoliciesStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders");

            migrationBuilder.AlterColumn<int>(
                name: "PoliciesStatusId",
                table: "PoliciesOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PoliciesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders",
                column: "PoliciesStatusId",
                principalTable: "PoliciesStatuses",
                principalColumn: "Id");
        }
    }
}
