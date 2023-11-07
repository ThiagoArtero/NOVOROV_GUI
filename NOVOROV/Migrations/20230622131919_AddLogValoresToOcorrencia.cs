using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddLogValoresToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracaoValor",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValorAlteradoPorId",
                table: "Ocorrencia",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorConteudoAnterior",
                table: "Ocorrencia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorConteudoAtual",
                table: "Ocorrencia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDiferenca",
                table: "Ocorrencia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDiferencaPercentual",
                table: "Ocorrencia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPerdaTotal",
                table: "Ocorrencia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_ValorAlteradoPorId",
                table: "Ocorrencia",
                column: "ValorAlteradoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Usuario_ValorAlteradoPorId",
                table: "Ocorrencia",
                column: "ValorAlteradoPorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Usuario_ValorAlteradoPorId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_ValorAlteradoPorId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "DataAlteracaoValor",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorAlteradoPorId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorConteudoAnterior",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorConteudoAtual",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorDiferenca",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorDiferencaPercentual",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ValorPerdaTotal",
                table: "Ocorrencia");

        }
    }
}
