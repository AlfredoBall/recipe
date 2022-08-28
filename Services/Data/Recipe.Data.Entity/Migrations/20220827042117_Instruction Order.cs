using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class InstructionOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Instruction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_Order",
                table: "Instruction",
                column: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instruction_Order",
                table: "Instruction");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Instruction");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Ingredient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
