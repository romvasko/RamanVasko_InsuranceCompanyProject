using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class CarOrder1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonCondition",
                table: "PoliciesOrders");

            migrationBuilder.CreateTable(
                name: "CarPolicyOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliciesOrderId = table.Column<int>(type: "int", nullable: false),
                    CarPolicyConditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPolicyOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPolicyOrder_CarPolicyConditions_CarPolicyConditionId",
                        column: x => x.CarPolicyConditionId,
                        principalTable: "CarPolicyConditions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPolicyOrder_PoliciesOrders_PoliciesOrderId",
                        column: x => x.PoliciesOrderId,
                        principalTable: "PoliciesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPolicyOrder_CarPolicyConditionId",
                table: "CarPolicyOrder",
                column: "CarPolicyConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPolicyOrder_PoliciesOrderId",
                table: "CarPolicyOrder",
                column: "PoliciesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPolicyOrder");

            migrationBuilder.AddColumn<string>(
                name: "JsonCondition",
                table: "PoliciesOrders",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
