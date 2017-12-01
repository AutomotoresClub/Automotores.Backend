using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddPromociones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 255, nullable: false),
                    EstablecimientoId = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Imagen = table.Column<string>(maxLength: 255, nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false),
                    Vigencia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promociones_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promociones_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromocionMercado",
                columns: table => new
                {
                    PromocionId = table.Column<int>(nullable: false),
                    MercadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionMercado", x => new { x.PromocionId, x.MercadoId });
                    table.ForeignKey(
                        name: "FK_PromocionMercado_Mercado_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromocionMercado_Promociones_PromocionId",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_EstablecimientoId",
                table: "Promociones",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Promociones_ServicioId",
                table: "Promociones",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionMercado_MercadoId",
                table: "PromocionMercado",
                column: "MercadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocionMercado");

            migrationBuilder.DropTable(
                name: "Promociones");
        }
    }
}
