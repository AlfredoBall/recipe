using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class Navigationproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Instruction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Instruction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Ingredient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID");
        }
    }
}
