using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Automotores.Backend.Migrations
{
    public partial class UpdateHorarioEstablecimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JornadaMañana",
                table: "HorarioEstablecimiento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "JornadaTarde",
                table: "HorarioEstablecimiento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubJornadaMañana",
                table: "HorarioEstablecimiento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubJornadaTarde",
                table: "HorarioEstablecimiento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JornadaMañana",
                table: "HorarioEstablecimiento");

            migrationBuilder.DropColumn(
                name: "JornadaTarde",
                table: "HorarioEstablecimiento");

            migrationBuilder.DropColumn(
                name: "SubJornadaMañana",
                table: "HorarioEstablecimiento");

            migrationBuilder.DropColumn(
                name: "SubJornadaTarde",
                table: "HorarioEstablecimiento");
        }
    }
}
