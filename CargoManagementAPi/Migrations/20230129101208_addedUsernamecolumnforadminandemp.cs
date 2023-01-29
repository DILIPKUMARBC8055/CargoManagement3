using Microsoft.EntityFrameworkCore.Migrations;

namespace CargoManagementAPi.Migrations
{
    public partial class addedUsernamecolumnforadminandemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Admin");
        }
    }
}
