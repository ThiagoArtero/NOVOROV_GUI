using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioFuncionalidadeToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioFuncionalidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionalidadeId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioFuncionalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioFuncionalidade_Funcionalidade_FuncionalidadeId",
                        column: x => x.FuncionalidadeId,
                        principalTable: "Funcionalidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioFuncionalidade_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioFuncionalidade_FuncionalidadeId",
                table: "UsuarioFuncionalidade",
                column: "FuncionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioFuncionalidade_UsuarioId",
                table: "UsuarioFuncionalidade",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioFuncionalidade");
        }
    }
}
