using Microsoft.EntityFrameworkCore.Migrations;

namespace FormGenerator.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Depth",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doors",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasFreezer",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Volume",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Products",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Doors",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasFreezer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Products");
        }
    }
}
