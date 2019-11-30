using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForAll.Data.Migrations
{
    public partial class MealAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dependency",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Diebetic",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "FoodMonthlyExpenses",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HIVStatus",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Pregnent",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoodName = table.Column<string>(nullable: true),
                    Carbohydrate = table.Column<string>(nullable: true),
                    Liqids = table.Column<string>(nullable: true),
                    Protein = table.Column<string>(nullable: true),
                    Fibre = table.Column<string>(nullable: true),
                    Energy = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropColumn(
                name: "Dependency",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Diebetic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FoodMonthlyExpenses",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HIVStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pregnent",
                table: "AspNetUsers");
        }
    }
}
