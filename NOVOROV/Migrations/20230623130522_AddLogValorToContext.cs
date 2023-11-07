using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddLogValorToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogValor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracaoValor = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValorAlteradoPorId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ValorPerdaTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorConteudoAnterior = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorConteudoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorDiferenca = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorDiferencaPercentual = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogValor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogValor_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogValor_Usuario_ValorAlteradoPorId",
                        column: x => x.ValorAlteradoPorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogValor_OcorrenciaId",
                table: "LogValor",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogValor_ValorAlteradoPorId",
                table: "LogValor",
                column: "ValorAlteradoPorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogValor");
        }
    }
}
