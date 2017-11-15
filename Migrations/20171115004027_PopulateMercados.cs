using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateMercados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Mercado (Nombre) Values ('Motocicleta  /  Motocarro  /  Cuatrimoto')");
            migrationBuilder.Sql("INSERT INTO Mercado (Nombre) Values ('Automovil  / Campero ó Camioneta')");
            migrationBuilder.Sql("INSERT INTO Mercado (Nombre) Values ('Microbus  / Buseta  /  Bus')");
            migrationBuilder.Sql("INSERT INTO Mercado (Nombre) Values ('Camion  /  Tracto camion  /  Volqueta')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Mercado WHERE Nombre IN ('Motocicleta  /  Motocarro  /  Cuatrimoto', 'Automovil  / Campero ó Camioneta', 'Microbus  / Buseta  /  Bus', 'Camion  /  Tracto camion  /  Volqueta')");
        }
    }
}
