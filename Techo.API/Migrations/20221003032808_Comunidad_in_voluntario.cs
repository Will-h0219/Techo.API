using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class Comunidad_in_voluntario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComunidadId",
                table: "Voluntario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voluntario_ComunidadId",
                table: "Voluntario",
                column: "ComunidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntario_Comunidad_ComunidadId",
                table: "Voluntario",
                column: "ComunidadId",
                principalTable: "Comunidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voluntario_Comunidad_ComunidadId",
                table: "Voluntario");

            migrationBuilder.DropIndex(
                name: "IX_Voluntario_ComunidadId",
                table: "Voluntario");

            migrationBuilder.DropColumn(
                name: "ComunidadId",
                table: "Voluntario");
        }
    }
}
