using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('ANTIOQUIA', 4)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('ATLANTICO', 5)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('BOLIVAR', 1)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('BOYACA', 5)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CALDAS', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CAQUETA', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CAUCA', 2)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CESAR', 5)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CORDOBA', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CUNDINAMARCA', 1)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CHOCO', 4)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('HUILA', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('LA GUAJIRA', 2)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('MAGDALENA', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('META', 4)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('NARIÑO', 2)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('N. DE SANTANDER', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('QUINDIO', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('RISARALDA', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('SANTANDER', 7)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('SUCRE', 5)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('TOLIMA', 7)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('VALLE DEL CAUCA', 2)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('ARAUCA', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('CASANARE', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('PUTUMAYO', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('SAN ANDRES', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('AMAZONAS', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('GUAINIA', 8)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('GUAVIARE', 2)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('VAUPES', 6)");
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('VICHADA', 7)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Departamentos");
        }
    }
}
