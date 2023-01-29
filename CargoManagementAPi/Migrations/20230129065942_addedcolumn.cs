using Microsoft.EntityFrameworkCore.Migrations;

namespace CargoManagementAPi.Migrations
{
    public partial class addedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "CargoOrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "CargoOrderDetails");
        }
    }
}
