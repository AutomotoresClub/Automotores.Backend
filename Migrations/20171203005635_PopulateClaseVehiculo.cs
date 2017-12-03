using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateClaseVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('MOTOCICLETA', 1)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('MOTOCARRO', 1)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('CUATRIMOTO', 1)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('AUTOMOVIL', 2)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('CAMIONETA Y CAMPEROS', 2)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('MICROBUS', 3)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('BUSETA', 3)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('BUS', 3)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('CAMIÓN', 4)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('TRACTO CAMIÓN', 4)");
            migrationBuilder.Sql("INSERT INTO ClaseVehiculo (Nombre, MercadoId) Values ('VOLQUETA', 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ClaseVehiculo");
        }
    }
}
