﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Entity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanItem",
                columns: table => new
                {
                    PlanItem_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanItem", x => x.PlanItem_ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Recipe_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Recipe_ID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Ingredient_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipe_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Ingredient_ID);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipe_Recipe_ID",
                        column: x => x.Recipe_ID,
                        principalTable: "Recipe",
                        principalColumn: "Recipe_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instruction",
                columns: table => new
                {
                    Instruction_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipe_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruction", x => x.Instruction_ID);
                    table.ForeignKey(
                        name: "FK_Instruction_Recipe_Recipe_ID",
                        column: x => x.Recipe_ID,
                        principalTable: "Recipe",
                        principalColumn: "Recipe_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Recipe_ID",
                table: "Ingredient",
                column: "Recipe_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_Order",
                table: "Instruction",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_Recipe_ID",
                table: "Instruction",
                column: "Recipe_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanItem_Text",
                table: "PlanItem",
                column: "Text",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Instruction");

            migrationBuilder.DropTable(
                name: "PlanItem");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
