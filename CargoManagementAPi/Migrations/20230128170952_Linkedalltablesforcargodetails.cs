using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CargoManagementAPi.Migrations
{
    public partial class Linkedalltablesforcargodetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cargo");

            migrationBuilder.AddColumn<int>(
                name: "CargoTypeId",
                table: "CargoOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "CargoOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "CargoOrderDetails",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "CargoOrderDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "CargoOrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Cargo",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrderDetails_CargoTypeId",
                table: "CargoOrderDetails",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoOrderDetails_CityId",
                table: "CargoOrderDetails",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrderDetails_CargoTypes_CargoTypeId",
                table: "CargoOrderDetails",
                column: "CargoTypeId",
                principalTable: "CargoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOrderDetails_Cities_CityId",
                table: "CargoOrderDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrderDetails_CargoTypes_CargoTypeId",
                table: "CargoOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CargoOrderDetails_Cities_CityId",
                table: "CargoOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrderDetails_CargoTypeId",
                table: "CargoOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoOrderDetails_CityId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "CargoTypeId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "CargoOrderDetails");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Cargo");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cargo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
