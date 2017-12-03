using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateServicioVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ServicioVehiculo (Nombre) Values ('PARTICULAR')");
            migrationBuilder.Sql("INSERT INTO ServicioVehiculo (Nombre) Values ('PÚBLICO')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ServicioVehiculo");
        }
    }
}
