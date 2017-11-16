using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateDiasSemana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Lunes')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Martes')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Miercoles')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Jueves')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Viernes')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Sabado')");
            migrationBuilder.Sql("INSERT INTO DiasSemana (Nombre) Values ('Domingo')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM DiasSemana");
        }
    }
}
