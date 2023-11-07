using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnUsuarioOperadorToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Usuario_UsuarioOperadorUsuarioId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_UsuarioOperadorUsuarioId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "UsuarioOperadorUsuarioId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioOperadorId",
                table: "Ocorrencia",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_UsuarioOperadorId",
                table: "Ocorrencia",
                column: "UsuarioOperadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Usuario_UsuarioOperadorId",
                table: "Ocorrencia",
                column: "UsuarioOperadorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Usuario_UsuarioOperadorId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_UsuarioOperadorId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioOperadorId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioOperadorUsuarioId",
                table: "Ocorrencia",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_UsuarioOperadorUsuarioId",
                table: "Ocorrencia",
                column: "UsuarioOperadorUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Usuario_UsuarioOperadorUsuarioId",
                table: "Ocorrencia",
                column: "UsuarioOperadorUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
