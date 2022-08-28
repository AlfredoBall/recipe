using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class ForeignKeyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "Instruction",
                newName: "Recipe_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_RecipeID",
                table: "Instruction",
                newName: "IX_Instruction_Recipe_ID");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "Ingredient",
                newName: "Recipe_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient",
                newName: "IX_Ingredient_Recipe_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_Recipe_ID",
                table: "Ingredient",
                column: "Recipe_ID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_Recipe_ID",
                table: "Instruction",
                column: "Recipe_ID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_Recipe_ID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_Recipe_ID",
                table: "Instruction");

            migrationBuilder.RenameColumn(
                name: "Recipe_ID",
                table: "Instruction",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_Recipe_ID",
                table: "Instruction",
                newName: "IX_Instruction_RecipeID");

            migrationBuilder.RenameColumn(
                name: "Recipe_ID",
                table: "Ingredient",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_Recipe_ID",
                table: "Ingredient",
                newName: "IX_Ingredient_RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
