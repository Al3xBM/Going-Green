using Microsoft.EntityFrameworkCore.Migrations;

namespace FormGenerator.Data.Migrations
{
    public partial class ExtendedDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagonal",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bluetooth",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Camera",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connectivity",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Fridge_Volume",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontalCamera",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave_Depth",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave_Height",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave_Power",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave_Volume",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microwave_Width",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RAM",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SimSlots",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Software",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Television_Diagonal",
                table: "Products",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacuumCleaner_Depth",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacuumCleaner_Height",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacuumCleaner_Power",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacuumCleaner_Volume",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VacuumCleaner_Width",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wifi",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bluetooth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Camera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Connectivity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fridge_Volume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FrontalCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Microwave_Depth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Microwave_Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Microwave_Power",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Microwave_Volume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Microwave_Width",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RAM",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SimSlots",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Software",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Television_Diagonal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VacuumCleaner_Depth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VacuumCleaner_Height",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VacuumCleaner_Power",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VacuumCleaner_Volume",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VacuumCleaner_Width",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "Products");

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                table: "Products",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Diagonal",
                table: "Products",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
