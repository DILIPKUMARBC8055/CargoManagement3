using Microsoft.EntityFrameworkCore.Migrations;

namespace CargoManagementAPi.Migrations
{
    public partial class AddedStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CargoStatusId",
                table: "CargoOrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoStatusStatusId",
                table: "CargoOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cargoStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrderDetails_CargoStatusStatusId",
                table: "CargoOrderDetails",
                column: "CargoStatusStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrderDetails_cargoStatuses_CargoStatusStatusId",
                table: "CargoOrderDetails",
                column: "CargoStatusStatusId",
                principalTable: "cargoStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrderDetails_cargoStatuses_CargoStatusStatusId",
                table: "CargoOrderDetails");

            migrationBuilder.DropTable(
                name: "cargoStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrderDetails_CargoStatusStatusId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "CargoStatusId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "CargoStatusStatusId",
                table: "CargoOrderDetails");
        }
    }
}
