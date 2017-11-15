using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateTipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Departamentos (Nombre, Indicativo) Values ('ANTIOQUIA',)");
            migrationBuilder.Sql("INSERT INTO TipoDocumento (Nombre) Values ('NIT')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TipoDocumento WHERE Nombre IN ('CC', 'NIT')");
        }
    }
}
