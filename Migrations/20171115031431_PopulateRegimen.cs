using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateRegimen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Regimen (Nombre) Values ('SIMPLIFICADO')");
            migrationBuilder.Sql("INSERT INTO Regimen (Nombre) Values ('COMÚN')");
            migrationBuilder.Sql("INSERT INTO Regimen (Nombre) Values ('GRAN CONTRIBUYENTE')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Regimen");
        }
    }
}
