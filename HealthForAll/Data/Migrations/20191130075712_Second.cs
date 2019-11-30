using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForAll.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AreaType",
                table: "Shelters",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AreaType",
                table: "Shelters",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
