using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateServicioEmergencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ServiciosEmergencia (Nombre) Values ('Servicio eléctrico')");
            migrationBuilder.Sql("INSERT INTO ServiciosEmergencia (Nombre) Values ('Servicio de grúa')");
            migrationBuilder.Sql("INSERT INTO ServiciosEmergencia (Nombre) Values ('Mecánica general')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ServiciosEmergencia");
        }
    }
}
