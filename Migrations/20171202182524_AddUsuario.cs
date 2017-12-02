using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 55, nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    Contraseña = table.Column<string>(maxLength: 16, nullable: false),
                    Correo = table.Column<string>(maxLength: 55, nullable: false),
                    DeviceId = table.Column<string>(maxLength: 100, nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CiudadId",
                table: "Usuarios",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
