using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseSetupProject.Data.Migrations
{
    public partial class UpdatePolicyOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JsonCondition",
                table: "PoliciesOrders",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JsonCondition",
                table: "PoliciesOrders");
        }
    }
}
