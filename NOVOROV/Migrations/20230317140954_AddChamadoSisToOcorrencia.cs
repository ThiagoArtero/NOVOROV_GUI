using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddChamadoSisToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReagendamentoSis",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConclusaoSis",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoSis",
                table: "Ocorrencia",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroEmpresa",
                table: "Ocorrencia",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacaoSis",
                table: "Ocorrencia",
                type: "varchar(500)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConclusaoSis",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "MotivoSis",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "NumeroEmpresa",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ObservacaoSis",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataReagendamentoSis",
                table: "Ocorrencia",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
