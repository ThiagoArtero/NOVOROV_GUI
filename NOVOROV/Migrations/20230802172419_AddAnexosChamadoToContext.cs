using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddAnexosChamadoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnexosChamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnexo = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataAnexo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<string>(type: "varchar(10)", nullable: true),
                    DescricaoAnexo = table.Column<string>(type: "varchar(300)", nullable: true),
                    TipoAnexoId = table.Column<int>(type: "int", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bytes = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    NumeroVersaoAnexo = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    ChamadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexosChamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnexosChamado_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnexosChamado_TipoAnexo_TipoAnexoId",
                        column: x => x.TipoAnexoId,
                        principalTable: "TipoAnexo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnexosChamado_Usuario_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexosChamado_AutorId",
                table: "AnexosChamado",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnexosChamado_ChamadoId",
                table: "AnexosChamado",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AnexosChamado_TipoAnexoId",
                table: "AnexosChamado",
                column: "TipoAnexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexosChamado");
        }
    }
}
