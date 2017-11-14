using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CamaraComercio = table.Column<string>(maxLength: 255, nullable: true),
                    CiudadId = table.Column<int>(nullable: false),
                    CodigoVerificacion = table.Column<int>(nullable: false),
                    ComentariosAdmin = table.Column<string>(maxLength: 255, nullable: true),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Nit = table.Column<int>(nullable: false),
                    NumeroEstablecimientos = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 16, nullable: false),
                    RazonSocial = table.Column<string>(maxLength: 50, nullable: false),
                    RegimenId = table.Column<int>(nullable: false),
                    RepresentanteIdentificacion = table.Column<int>(nullable: false),
                    RepresentanteNombre = table.Column<string>(maxLength: 50, nullable: false),
                    Rut = table.Column<string>(maxLength: 255, nullable: true),
                    SitioWeb = table.Column<string>(maxLength: 255, nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresas_Regimen_RegimenId",
                        column: x => x.RegimenId,
                        principalTable: "Regimen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresas_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaMercado",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false),
                    MercadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaMercado", x => new { x.EmpresaId, x.MercadoId });
                    table.ForeignKey(
                        name: "FK_EmpresaMercado_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaMercado_Mercado_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaServicio",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaServicio", x => new { x.EmpresaId, x.ServicioId });
                    table.ForeignKey(
                        name: "FK_EmpresaServicio_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaServicio_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaMercado_MercadoId",
                table: "EmpresaMercado",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CiudadId",
                table: "Empresas",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_RegimenId",
                table: "Empresas",
                column: "RegimenId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TipoDocumentoId",
                table: "Empresas",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaServicio_ServicioId",
                table: "EmpresaServicio",
                column: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaMercado");

            migrationBuilder.DropTable(
                name: "EmpresaServicio");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
