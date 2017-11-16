using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddEstablecimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Establecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdministradorId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Imagen = table.Column<string>(maxLength: 255, nullable: true),
                    Latitud = table.Column<float>(nullable: false),
                    Longitud = table.Column<float>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    NombreContacto = table.Column<string>(maxLength: 50, nullable: false),
                    Ruta = table.Column<string>(maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    TelefonoContacto = table.Column<string>(maxLength: 10, nullable: false),
                    TipoJornada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establecimiento_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Establecimiento_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establecimiento_AdministradorId",
                table: "Establecimiento",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Establecimiento_CiudadId",
                table: "Establecimiento",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establecimiento");
        }
    }
}
