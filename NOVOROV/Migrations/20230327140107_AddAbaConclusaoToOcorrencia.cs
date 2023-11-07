using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddAbaConclusaoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conclusao",
                table: "Ocorrencia",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusao",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiasConclusaoConclusao",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiasConclusaoSis",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvidenciaConclusao",
                table: "Ocorrencia",
                type: "varchar(500)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Conclusao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DataConclusao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DiasConclusaoConclusao",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DiasConclusaoSis",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ProvidenciaConclusao",
                table: "Ocorrencia");
        }
    }
}
