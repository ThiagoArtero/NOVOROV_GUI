using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddBibliotecaToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoBiblioteca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoBiblioteca = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBiblioteca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescricaoAnexo = table.Column<string>(type: "varchar(300)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    AnalistaSolicitanteId = table.Column<int>(type: "int", nullable: true),
                    AnalistaSolicitanteUsuarioId = table.Column<string>(type: "varchar(10)", nullable: true),
                    NomeAnexo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bytes = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    TipoBibliotecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biblioteca_TipoBiblioteca_TipoBibliotecaId",
                        column: x => x.TipoBibliotecaId,
                        principalTable: "TipoBiblioteca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biblioteca_Usuario_AnalistaSolicitanteUsuarioId",
                        column: x => x.AnalistaSolicitanteUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_AnalistaSolicitanteUsuarioId",
                table: "Biblioteca",
                column: "AnalistaSolicitanteUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_TipoBibliotecaId",
                table: "Biblioteca",
                column: "TipoBibliotecaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biblioteca");

            migrationBuilder.DropTable(
                name: "TipoBiblioteca");
        }
    }
}
