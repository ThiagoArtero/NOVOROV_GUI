using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddLogToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: true),
                    OperadorId = table.Column<string>(type: "varchar(10)", nullable: false),
                    IpOperador = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Hostname = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeCampo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ConteudoAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConteudoAtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acao = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Log_Usuario_OperadorId",
                        column: x => x.OperadorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_OcorrenciaId",
                table: "Log",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_OperadorId",
                table: "Log",
                column: "OperadorId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                name: "Log");

        }
    }
}
