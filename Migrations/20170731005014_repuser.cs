using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAche.Migrations
{
    public partial class repuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TextExtensions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextExtensions_UserId",
                table: "TextExtensions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextExtensions_Users_UserId",
                table: "TextExtensions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextExtensions_Users_UserId",
                table: "TextExtensions");

            migrationBuilder.DropIndex(
                name: "IX_TextExtensions_UserId",
                table: "TextExtensions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TextExtensions");
        }
    }
}
