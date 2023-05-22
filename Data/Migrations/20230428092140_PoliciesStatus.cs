using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class PoliciesStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PoliciesOrders",
                newName: "StatusId");

            migrationBuilder.AddColumn<int>(
                name: "PoliciesStatusId",
                table: "PoliciesOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PoliciesStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesOrders_PoliciesStatusId",
                table: "PoliciesOrders",
                column: "PoliciesStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders",
                column: "PoliciesStatusId",
                principalTable: "PoliciesStatuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesOrders_PoliciesStatuses_PoliciesStatusId",
                table: "PoliciesOrders");

            migrationBuilder.DropTable(
                name: "PoliciesStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesOrders_PoliciesStatusId",
                table: "PoliciesOrders");

            migrationBuilder.DropColumn(
                name: "PoliciesStatusId",
                table: "PoliciesOrders");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "PoliciesOrders",
                newName: "Status");
        }
    }
}
