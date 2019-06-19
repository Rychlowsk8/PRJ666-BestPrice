using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPrice.Data.Migrations
{
    public partial class ConstructorHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "getNotified",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "saveSearches",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "getNotified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "saveSearches",
                table: "AspNetUsers");
        }
    }
}
