using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddTratamentoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroRegistroPolicial",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeguimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SeguimentoId",
                table: "Ocorrencia",
                column: "SeguimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Seguimento_SeguimentoId",
                table: "Ocorrencia",
                column: "SeguimentoId",
                principalTable: "Seguimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Seguimento_SeguimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SeguimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "NumeroRegistroPolicial",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "SeguimentoId",
                table: "Ocorrencia");
        }
    }
}
