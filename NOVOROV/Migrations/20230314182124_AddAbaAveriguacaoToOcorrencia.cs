using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddAbaAveriguacaoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusaoAveriguacao",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicioAveriguacao",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiasConclusao",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelAveriguacao",
                table: "Ocorrencia",
                type: "varchar(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusaoAveriguacao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DataInicioAveriguacao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DiasConclusao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ResponsavelAveriguacao",
                table: "Ocorrencia");
        }
    }
}
