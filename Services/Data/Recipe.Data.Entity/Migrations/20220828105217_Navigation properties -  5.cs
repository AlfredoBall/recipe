using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class Navigationproperties5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_Recipe_ID",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_Recipe_ID",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Recipe_ID1",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "RecipeID",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient",
                column: "RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeID",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Recipe_ID1",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Recipe_ID",
                table: "Ingredient",
                column: "Recipe_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_Recipe_ID",
                table: "Ingredient",
                column: "Recipe_ID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
