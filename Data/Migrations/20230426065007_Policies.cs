using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class Policies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliciesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PoliciesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliciesTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliciesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliciesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliciesTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policies_PoliciesTypes_PoliciesTypeId",
                        column: x => x.PoliciesTypeId,
                        principalTable: "PoliciesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PoliciesId",
                table: "AspNetUsers",
                column: "PoliciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_PoliciesTypeId",
                table: "Policies",
                column: "PoliciesTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Policies_PoliciesId",
                table: "AspNetUsers",
                column: "PoliciesId",
                principalTable: "Policies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Policies_PoliciesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PoliciesTypes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PoliciesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PoliciesId",
                table: "AspNetUsers");
        }
    }
}
