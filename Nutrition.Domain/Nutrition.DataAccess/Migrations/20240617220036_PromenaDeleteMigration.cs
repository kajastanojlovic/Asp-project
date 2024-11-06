using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrition.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PromenaDeleteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biometric_BodyBiometric_BodyId",
                table: "Biometric");

            migrationBuilder.DropForeignKey(
                name: "FK_Biometric_Users_UserId",
                table: "Biometric");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoals_Users_UserId",
                table: "DailyGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsMacronutrients_Foods_FoodId",
                table: "FoodsMacronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsMacronutrients_Macronutrients_MacronutrientId",
                table: "FoodsMacronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_GoalStatuses_GoalStatusId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_Foods_FoodId",
                table: "MealsFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_Meals_MealId",
                table: "MealsFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods");

            migrationBuilder.AddForeignKey(
                name: "FK_Biometric_BodyBiometric_BodyId",
                table: "Biometric",
                column: "BodyId",
                principalTable: "BodyBiometric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Biometric_Users_UserId",
                table: "Biometric",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoals_Users_UserId",
                table: "DailyGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsMacronutrients_Foods_FoodId",
                table: "FoodsMacronutrients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsMacronutrients_Macronutrients_MacronutrientId",
                table: "FoodsMacronutrients",
                column: "MacronutrientId",
                principalTable: "Macronutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_GoalStatuses_GoalStatusId",
                table: "Goals",
                column: "GoalStatusId",
                principalTable: "GoalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_Foods_FoodId",
                table: "MealsFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_Meals_MealId",
                table: "MealsFoods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods",
                column: "ServingSizeId",
                principalTable: "ServingSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biometric_BodyBiometric_BodyId",
                table: "Biometric");

            migrationBuilder.DropForeignKey(
                name: "FK_Biometric_Users_UserId",
                table: "Biometric");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoals_Users_UserId",
                table: "DailyGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsMacronutrients_Foods_FoodId",
                table: "FoodsMacronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodsMacronutrients_Macronutrients_MacronutrientId",
                table: "FoodsMacronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_GoalStatuses_GoalStatusId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_Foods_FoodId",
                table: "MealsFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_Meals_MealId",
                table: "MealsFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods");

            migrationBuilder.AddForeignKey(
                name: "FK_Biometric_BodyBiometric_BodyId",
                table: "Biometric",
                column: "BodyId",
                principalTable: "BodyBiometric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Biometric_Users_UserId",
                table: "Biometric",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoals_Users_UserId",
                table: "DailyGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsMacronutrients_Foods_FoodId",
                table: "FoodsMacronutrients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsMacronutrients_Macronutrients_MacronutrientId",
                table: "FoodsMacronutrients",
                column: "MacronutrientId",
                principalTable: "Macronutrients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_GoalStatuses_GoalStatusId",
                table: "Goals",
                column: "GoalStatusId",
                principalTable: "GoalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_Foods_FoodId",
                table: "MealsFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_Meals_MealId",
                table: "MealsFoods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods",
                column: "ServingSizeId",
                principalTable: "ServingSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
