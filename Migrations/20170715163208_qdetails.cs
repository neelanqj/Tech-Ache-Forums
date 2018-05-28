using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAche.Migrations
{
    public partial class qdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Questions_QuestionId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Questions",
                newName: "Details");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Questions_QuestionId",
                table: "Photos",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Questions_QuestionId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Questions",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Questions_QuestionId",
                table: "Photos",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
