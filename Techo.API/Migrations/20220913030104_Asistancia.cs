using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class Asistancia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Comunidad_ComunidadId",
                table: "Actividad");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Voluntario_VoluntarioId",
                table: "Actividad");

            migrationBuilder.AlterColumn<int>(
                name: "VoluntarioId",
                table: "Actividad",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ComunidadId",
                table: "Actividad",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    VoluntarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => new { x.ActividadId, x.VoluntarioId });
                    table.ForeignKey(
                        name: "FK_Asistencia_Actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencia_Voluntario_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_VoluntarioId",
                table: "Asistencia",
                column: "VoluntarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Comunidad_ComunidadId",
                table: "Actividad",
                column: "ComunidadId",
                principalTable: "Comunidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Voluntario_VoluntarioId",
                table: "Actividad",
                column: "VoluntarioId",
                principalTable: "Voluntario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Comunidad_ComunidadId",
                table: "Actividad");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividad_Voluntario_VoluntarioId",
                table: "Actividad");

            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.AlterColumn<int>(
                name: "VoluntarioId",
                table: "Actividad",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComunidadId",
                table: "Actividad",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Comunidad_ComunidadId",
                table: "Actividad",
                column: "ComunidadId",
                principalTable: "Comunidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividad_Voluntario_VoluntarioId",
                table: "Actividad",
                column: "VoluntarioId",
                principalTable: "Voluntario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
