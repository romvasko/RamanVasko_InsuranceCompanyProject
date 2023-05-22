using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class PoliciesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Policies_PoliciesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PoliciesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PoliciesId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliciesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PoliciesId",
                table: "AspNetUsers",
                column: "PoliciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Policies_PoliciesId",
                table: "AspNetUsers",
                column: "PoliciesId",
                principalTable: "Policies",
                principalColumn: "Id");
        }
    }
}
