using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForAll.Data.Migrations
{
    public partial class RemoveNameColumnInMealTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Meals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Meals",
                nullable: true);
        }
    }
}
