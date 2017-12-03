using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CiudadId = table.Column<int>(nullable: false),
                    ColorVehiculoId = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Imagen = table.Column<string>(maxLength: 255, nullable: true),
                    LineaId = table.Column<int>(nullable: false),
                    Modelo = table.Column<string>(maxLength: 5, nullable: false),
                    Placa = table.Column<string>(maxLength: 8, nullable: false),
                    ServicioVehiculoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    VigenciaSoat = table.Column<DateTime>(nullable: false),
                    VigenciaTecnomecanica = table.Column<DateTime>(nullable: false),
                    VigenciaTodoriesgo = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_ColorVehiculo_ColorVehiculoId",
                        column: x => x.ColorVehiculoId,
                        principalTable: "ColorVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_ServicioVehiculo_ServicioVehiculoId",
                        column: x => x.ServicioVehiculoId,
                        principalTable: "ServicioVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_CiudadId",
                table: "Vehiculos",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ColorVehiculoId",
                table: "Vehiculos",
                column: "ColorVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_LineaId",
                table: "Vehiculos",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ServicioVehiculoId",
                table: "Vehiculos",
                column: "ServicioVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_UsuarioId",
                table: "Vehiculos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
