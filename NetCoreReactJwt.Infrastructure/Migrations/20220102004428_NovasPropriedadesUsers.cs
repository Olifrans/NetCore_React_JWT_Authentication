using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreReactJwt.Infrastructure.Migrations
{
    public partial class NovasPropriedadesUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegister",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegister",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Users");
        }
    }
}
