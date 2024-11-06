using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrition.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DodavanjeMealFoodConfigMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealsFoods",
                table: "MealsFoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealsFoods",
                table: "MealsFoods",
                columns: new[] { "MealId", "FoodId", "ServingSizeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealsFoods",
                table: "MealsFoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealsFoods",
                table: "MealsFoods",
                columns: new[] { "MealId", "FoodId" });
        }
    }
}
