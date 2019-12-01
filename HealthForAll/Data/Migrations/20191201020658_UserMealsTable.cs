using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthForAll.Data.Migrations
{
    public partial class UserMealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMeals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FoodName = table.Column<string>(nullable: true),
                    Carbohydrate = table.Column<string>(nullable: true),
                    Liqids = table.Column<string>(nullable: true),
                    Protein = table.Column<string>(nullable: true),
                    Fibre = table.Column<string>(nullable: true),
                    Energy = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Budget = table.Column<decimal>(nullable: false),
                    Dependaents = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    MealDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMeals");
        }
    }
}
