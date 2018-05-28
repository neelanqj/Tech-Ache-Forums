using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAche.Migrations
{
    public partial class usergender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true,
                oldClrType: typeof(char));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
