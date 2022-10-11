using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Techo.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCiudad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comuna_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legalizado = table.Column<bool>(type: "bit", nullable: false),
                    DecretoLegalizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DensidadMujeres = table.Column<float>(type: "real", nullable: true),
                    DensidadHombres = table.Column<float>(type: "real", nullable: true),
                    ComunaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunidad_Comuna_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "Comuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voluntario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CoordinatorProfile = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    ComunidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntario_Comunidad_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voluntario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaJornada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsMesaTrabajo = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HabitantesParticipantes = table.Column<int>(type: "int", nullable: false),
                    VoluntarioId = table.Column<int>(type: "int", nullable: true),
                    ComunidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Comunidad_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Voluntario_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadAlternativa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadAlternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadAlternativa_Actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "MesaTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemasTratados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compromisos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkActa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesaTrabajo_Actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ComunidadId",
                table: "Actividad",
                column: "ComunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_VoluntarioId",
                table: "Actividad",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadAlternativa_ActividadId",
                table: "ActividadAlternativa",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_VoluntarioId",
                table: "Asistencia",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comuna_CiudadId",
                table: "Comuna",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunidad_ComunaId",
                table: "Comunidad",
                column: "ComunaId");

            migrationBuilder.CreateIndex(
                name: "IX_MesaTrabajo_ActividadId",
                table: "MesaTrabajo",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntario_ComunidadId",
                table: "Voluntario",
                column: "ComunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntario_RolId",
                table: "Voluntario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadAlternativa");

            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "MesaTrabajo");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Voluntario");

            migrationBuilder.DropTable(
                name: "Comunidad");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Comuna");

            migrationBuilder.DropTable(
                name: "Ciudad");
        }
    }
}
