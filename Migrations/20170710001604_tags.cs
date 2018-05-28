using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechAche.Migrations
{
    public partial class tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TagId",
                table: "Questions",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tags_TagId",
                table: "Questions",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tags_TagId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TagId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Questions");
        }
    }
}
