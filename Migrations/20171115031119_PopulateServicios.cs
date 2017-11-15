using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class PopulateServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('COMBUSTIBLES Y LUBRICANTES', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/combustibles-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('MECÁNICA Y MANTENIMIENTOS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/mecanica-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('ESTETICA Y LAVADO (ASEO-LUJOS-COJINERIA)', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/estetica-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('Servicios ELECTRICO Y AIRE ACONDICIONADO', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/Servicios-electrico-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('VENTA DE VEHICULOS NUEVOS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/venta-vehiculos-nuevos-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('LLANTAS Y RINES', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/llantas-rines-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('LÁMINAS Y PINTURAS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/laminas-pintura-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('CDA (CENTRO DE DIAGNOSTICO AUTOMOTOR)', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/cda-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('FINANCIACIÓN', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/financiacion-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('REPUESTOS Y ACCESORIOS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/repuestos-accesorios-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('SEGUROS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/seguros-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('ASESORIAS Y TRAMITES', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/asesoria-blue.png')");
            migrationBuilder.Sql("INSERT INTO Servicios (Nombre, Imagen) Values ('VENTA DE VEHICULOS USADOS', 'http://d14gy5s8yv1ger.cloudfront.net/ASSETS/venta-vehiculos-usados-blue.png')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE From Servicios");
        }
    }
}
