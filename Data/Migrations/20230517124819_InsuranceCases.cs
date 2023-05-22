using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class InsuranceCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliceId = table.Column<int>(type: "int", nullable: false),
                    PoliciesOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceCase_PoliciesOrders_PoliciesOrderId",
                        column: x => x.PoliciesOrderId,
                        principalTable: "PoliciesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceCase_PoliciesOrderId",
                table: "InsuranceCase",
                column: "PoliciesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceCase");
        }
    }
}
