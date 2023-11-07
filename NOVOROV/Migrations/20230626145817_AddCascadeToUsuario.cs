using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFuncionalidade_Usuario_UsuarioId",
                table: "UsuarioFuncionalidade");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFuncionalidade_Usuario_UsuarioId",
                table: "UsuarioFuncionalidade",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFuncionalidade_Usuario_UsuarioId",
                table: "UsuarioFuncionalidade");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFuncionalidade_Usuario_UsuarioId",
                table: "UsuarioFuncionalidade",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
