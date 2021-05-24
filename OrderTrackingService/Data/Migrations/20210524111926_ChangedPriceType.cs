using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderTrackingService.Data.Migrations
{
    public partial class ChangedPriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
