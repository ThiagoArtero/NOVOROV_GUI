using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsavelAveriguacaoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponsavelAveriguacao",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelAveriguacaoId",
                table: "Ocorrencia",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_ResponsavelAveriguacaoId",
                table: "Ocorrencia",
                column: "ResponsavelAveriguacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Usuario_ResponsavelAveriguacaoId",
                table: "Ocorrencia",
                column: "ResponsavelAveriguacaoId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Usuario_ResponsavelAveriguacaoId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_ResponsavelAveriguacaoId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ResponsavelAveriguacaoId",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<string>(
                name: "ResponsavelAveriguacao",
                table: "Ocorrencia",
                type: "varchar(10)",
                nullable: true);
        }
    }
}
