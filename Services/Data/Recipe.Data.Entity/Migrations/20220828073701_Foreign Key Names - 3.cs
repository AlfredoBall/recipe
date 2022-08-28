using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class ForeignKeyNames3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Instruction_ID",
                table: "Instruction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Ingredient_ID",
                table: "Ingredient",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_Ingredient_ID",
                table: "Ingredient",
                column: "Ingredient_ID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_Instruction_ID",
                table: "Instruction",
                column: "Instruction_ID",
                principalTable: "Recipe",
                principalColumn: "Recipe_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_Ingredient_ID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_Instruction_ID",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "Instruction_ID",
                table: "Instruction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Ingredient_ID",
                table: "Ingredient",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
