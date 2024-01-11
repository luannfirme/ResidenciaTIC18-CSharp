using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techmed.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Sitomas",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Medicos");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Pacientes",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Crm",
                table: "Medicos",
                newName: "CRM");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Medicos",
                newName: "CPF");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Medicos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Salario",
                table: "Medicos",
                type: "decimal(65,30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Medicos");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Pacientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CRM",
                table: "Medicos",
                newName: "Crm");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Medicos",
                newName: "Cpf");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Pacientes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sitomas",
                table: "Pacientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Medicos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
