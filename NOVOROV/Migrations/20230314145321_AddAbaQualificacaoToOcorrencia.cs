using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddAbaQualificacaoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CmcId",
                table: "Usuario",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAcionamentoProntoAtendimento",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GestaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GestaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "Observacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GestaoPerda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGestaoPerda = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestaoPerda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestaoQualidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGestaoQualidade = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestaoQualidade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CmcId",
                table: "Usuario",
                column: "CmcId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_GestaoPerdaId",
                table: "Ocorrencia",
                column: "GestaoPerdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_GestaoQualidadeId",
                table: "Ocorrencia",
                column: "GestaoQualidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacao_OcorrenciaId",
                table: "Observacao",
                column: "OcorrenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observacao_Ocorrencia_OcorrenciaId",
                table: "Observacao",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia",
                column: "GestaoPerdaId",
                principalTable: "GestaoPerda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia",
                column: "GestaoQualidadeId",
                principalTable: "GestaoQualidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Cmc_CmcId",
                table: "Usuario",
                column: "CmcId",
                principalTable: "Cmc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observacao_Ocorrencia_OcorrenciaId",
                table: "Observacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Cmc_CmcId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "GestaoPerda");

            migrationBuilder.DropTable(
                name: "GestaoQualidade");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_CmcId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_GestaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_GestaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Observacao_OcorrenciaId",
                table: "Observacao");

            migrationBuilder.DropColumn(
                name: "CmcId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataAcionamentoProntoAtendimento",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "GestaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "GestaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "Observacao");
        }
    }
}
