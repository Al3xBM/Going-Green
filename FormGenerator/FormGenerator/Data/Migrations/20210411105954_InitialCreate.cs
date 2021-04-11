using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormGenerator.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Series = table.Column<string>(type: "TEXT", nullable: true),
                    Consumption = table.Column<string>(type: "TEXT", nullable: true),
                    EnergyClass = table.Column<string>(type: "TEXT", nullable: true),
                    Colour = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
