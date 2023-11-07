using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AutorIdConvertToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexo_Usuario_AutorUsuarioId",
                table: "Anexo");

            migrationBuilder.DropIndex(
                name: "IX_Anexo_AutorUsuarioId",
                table: "Anexo");

            migrationBuilder.DropColumn(
                name: "AutorUsuarioId",
                table: "Anexo");

            migrationBuilder.AlterColumn<string>(
                name: "AutorId",
                table: "Anexo",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_AutorId",
                table: "Anexo",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexo_Usuario_AutorId",
                table: "Anexo",
                column: "AutorId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexo_Usuario_AutorId",
                table: "Anexo");

            migrationBuilder.DropIndex(
                name: "IX_Anexo_AutorId",
                table: "Anexo");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Anexo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "AutorUsuarioId",
                table: "Anexo",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_AutorUsuarioId",
                table: "Anexo",
                column: "AutorUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anexo_Usuario_AutorUsuarioId",
                table: "Anexo",
                column: "AutorUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }
    }
}
