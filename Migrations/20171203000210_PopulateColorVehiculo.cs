using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateColorVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('BLANCO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('AZUL')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('ROJO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('AMARILLO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('NEGRO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('VERDE')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('VINOTINTO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('CAFÉ')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('GRIS')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('NEGRA Y ROJA')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('NEGRA Y BLANCA')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('NEGRA Y AZUL')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('BLANCO Y ROJO')");
            migrationBuilder.Sql("INSERT INTO ColorVehiculo (Nombre) Values ('NEGRO Y VERDE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ColorVehiculo");
        }
    }
}
