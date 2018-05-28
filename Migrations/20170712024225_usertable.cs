using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechAche.Migrations
{
    public partial class usertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Profiles_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Profiles_UserId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<char>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    TechAcheId = table.Column<Guid>(nullable: false),
                    LastPostDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),                    
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<char>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    TechAcheId = table.Column<Guid>(nullable: false),
                    LastPostDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),                    
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Profiles_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Profiles_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
