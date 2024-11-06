using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrition.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Meals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealType",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
