using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class zona_inComunidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZonaId",
                table: "Comunidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comunidad_ZonaId",
                table: "Comunidad",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunidad_Zona_ZonaId",
                table: "Comunidad",
                column: "ZonaId",
                principalTable: "Zona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunidad_Zona_ZonaId",
                table: "Comunidad");

            migrationBuilder.DropIndex(
                name: "IX_Comunidad_ZonaId",
                table: "Comunidad");

            migrationBuilder.DropColumn(
                name: "ZonaId",
                table: "Comunidad");
        }
    }
}
