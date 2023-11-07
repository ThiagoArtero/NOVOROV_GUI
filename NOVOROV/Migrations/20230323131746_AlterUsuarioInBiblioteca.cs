using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AlterUsuarioInBiblioteca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Usuario_AnalistaSolicitanteUsuarioId",
                table: "Biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_Biblioteca_AnalistaSolicitanteUsuarioId",
                table: "Biblioteca");

            migrationBuilder.DropColumn(
                name: "AnalistaSolicitanteUsuarioId",
                table: "Biblioteca");

            migrationBuilder.AlterColumn<string>(
                name: "AnalistaSolicitanteId",
                table: "Biblioteca",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_AnalistaSolicitanteId",
                table: "Biblioteca",
                column: "AnalistaSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Usuario_AnalistaSolicitanteId",
                table: "Biblioteca",
                column: "AnalistaSolicitanteId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Usuario_AnalistaSolicitanteId",
                table: "Biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_Biblioteca_AnalistaSolicitanteId",
                table: "Biblioteca");

            migrationBuilder.AlterColumn<int>(
                name: "AnalistaSolicitanteId",
                table: "Biblioteca",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalistaSolicitanteUsuarioId",
                table: "Biblioteca",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_AnalistaSolicitanteUsuarioId",
                table: "Biblioteca",
                column: "AnalistaSolicitanteUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Usuario_AnalistaSolicitanteUsuarioId",
                table: "Biblioteca",
                column: "AnalistaSolicitanteUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
