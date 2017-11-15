using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateMercado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepresentanteNombre",
                table: "Empresas",
                newName: "NombreRepresentante");

            migrationBuilder.RenameColumn(
                name: "RepresentanteIdentificacion",
                table: "Empresas",
                newName: "IdentificacionRepresentante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRepresentante",
                table: "Empresas",
                newName: "RepresentanteNombre");

            migrationBuilder.RenameColumn(
                name: "IdentificacionRepresentante",
                table: "Empresas",
                newName: "RepresentanteIdentificacion");
        }
    }
}
