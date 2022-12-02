using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class fechaSalida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                table: "Voluntario",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaSalida",
                table: "Voluntario");
        }
    }
}
