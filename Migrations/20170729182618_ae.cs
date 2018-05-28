using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAche.Migrations
{
    public partial class ae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Answers_AnswerId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AnswerId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId1",
                table: "TextExtensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextExtensions_AnswerId1",
                table: "TextExtensions",
                column: "AnswerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TextExtensions_Answers_AnswerId1",
                table: "TextExtensions",
                column: "AnswerId1",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextExtensions_Answers_AnswerId1",
                table: "TextExtensions");

            migrationBuilder.DropIndex(
                name: "IX_TextExtensions_AnswerId1",
                table: "TextExtensions");

            migrationBuilder.DropColumn(
                name: "AnswerId1",
                table: "TextExtensions");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerId",
                table: "Answers",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Answers_AnswerId",
                table: "Answers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
