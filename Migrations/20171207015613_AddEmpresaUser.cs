using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class AddEmpresaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Empresas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UserId",
                table: "Empresas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AspNetUsers_UserId",
                table: "Empresas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AspNetUsers_UserId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_UserId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Empresas");
        }
    }
}
