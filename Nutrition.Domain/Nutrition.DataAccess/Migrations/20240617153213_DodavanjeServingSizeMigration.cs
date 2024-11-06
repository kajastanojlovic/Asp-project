using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutrition.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DodavanjeServingSizeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "MealsFoods");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "MealsFoods",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ServingSizeId",
                table: "MealsFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServingSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServingSizeUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingSizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealsFoods_ServingSizeId",
                table: "MealsFoods",
                column: "ServingSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods",
                column: "ServingSizeId",
                principalTable: "ServingSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealsFoods_ServingSizes_ServingSizeId",
                table: "MealsFoods");

            migrationBuilder.DropTable(
                name: "ServingSizes");

            migrationBuilder.DropIndex(
                name: "IX_MealsFoods_ServingSizeId",
                table: "MealsFoods");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MealsFoods");

            migrationBuilder.DropColumn(
                name: "ServingSizeId",
                table: "MealsFoods");

            migrationBuilder.AddColumn<decimal>(
                name: "ServingSize",
                table: "MealsFoods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
