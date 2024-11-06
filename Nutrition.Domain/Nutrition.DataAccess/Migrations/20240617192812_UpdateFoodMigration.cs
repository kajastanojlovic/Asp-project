using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrition.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesPer100g",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "FoodsMacronutrients",
                newName: "AmountMacronutrientsPer100g");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountMacronutrientsPer100g",
                table: "FoodsMacronutrients",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "CaloriesPer100g",
                table: "Foods",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
