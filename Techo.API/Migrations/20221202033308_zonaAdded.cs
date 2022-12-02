using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class zonaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZonaId",
                table: "Voluntario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voluntario_ZonaId",
                table: "Voluntario",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntario_Zona_ZonaId",
                table: "Voluntario",
                column: "ZonaId",
                principalTable: "Zona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voluntario_Zona_ZonaId",
                table: "Voluntario");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropIndex(
                name: "IX_Voluntario_ZonaId",
                table: "Voluntario");

            migrationBuilder.DropColumn(
                name: "ZonaId",
                table: "Voluntario");
        }
    }
}
