using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class RemoveAdministradorEmailYPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Administradores");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Administradores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_UserId",
                table: "Administradores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_UserId",
                table: "Administradores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_AspNetUsers_UserId",
                table: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_UserId",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Administradores");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Administradores",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Administradores",
                maxLength: 16,
                nullable: true);
        }
    }
}
