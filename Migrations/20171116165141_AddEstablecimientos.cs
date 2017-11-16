using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddEstablecimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstablecimientoMercado",
                columns: table => new
                {
                    EstablecimientoId = table.Column<int>(nullable: false),
                    MercadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablecimientoMercado", x => new { x.EstablecimientoId, x.MercadoId });
                    table.ForeignKey(
                        name: "FK_EstablecimientoMercado_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablecimientoMercado_Mercado_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstablecimientoServicio",
                columns: table => new
                {
                    EstablecimientoId = table.Column<int>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablecimientoServicio", x => new { x.EstablecimientoId, x.ServicioId });
                    table.ForeignKey(
                        name: "FK_EstablecimientoServicio_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablecimientoServicio_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosEmergencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosEmergencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorarioEstablecimiento",
                columns: table => new
                {
                    EstablecimientoId = table.Column<int>(nullable: false),
                    DiasSemanaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioEstablecimiento", x => new { x.EstablecimientoId, x.DiasSemanaId });
                    table.ForeignKey(
                        name: "FK_HorarioEstablecimiento_DiasSemana_DiasSemanaId",
                        column: x => x.DiasSemanaId,
                        principalTable: "DiasSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorarioEstablecimiento_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstablecimientoServicioEmergencia",
                columns: table => new
                {
                    EstablecimientoId = table.Column<int>(nullable: false),
                    ServicioEmergenciId = table.Column<int>(nullable: false),
                    ServicioEmergenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablecimientoServicioEmergencia", x => new { x.EstablecimientoId, x.ServicioEmergenciId });
                    table.ForeignKey(
                        name: "FK_EstablecimientoServicioEmergencia_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablecimientoServicioEmergencia_ServiciosEmergencia_ServicioEmergenciaId",
                        column: x => x.ServicioEmergenciaId,
                        principalTable: "ServiciosEmergencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstablecimientoMercado_MercadoId",
                table: "EstablecimientoMercado",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablecimientoServicio_ServicioId",
                table: "EstablecimientoServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablecimientoServicioEmergencia_ServicioEmergenciaId",
                table: "EstablecimientoServicioEmergencia",
                column: "ServicioEmergenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEstablecimiento_DiasSemanaId",
                table: "HorarioEstablecimiento",
                column: "DiasSemanaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstablecimientoMercado");

            migrationBuilder.DropTable(
                name: "EstablecimientoServicio");

            migrationBuilder.DropTable(
                name: "EstablecimientoServicioEmergencia");

            migrationBuilder.DropTable(
                name: "HorarioEstablecimiento");

            migrationBuilder.DropTable(
                name: "ServiciosEmergencia");

            migrationBuilder.DropTable(
                name: "DiasSemana");
        }
    }
}
