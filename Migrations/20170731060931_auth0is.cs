using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAche.Migrations
{
    public partial class auth0is : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechAcheId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Auth0Id",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntegrationId",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auth0Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IntegrationId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "TechAcheId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
