using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioAlteracaoOcorrenciaToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlteracaoOcorrencia_OcorrenciaId",
                table: "AlteracaoOcorrencia");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracaoOcorrenciaId",
                table: "Ocorrencia",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoOcorrencia_OcorrenciaId",
                table: "AlteracaoOcorrencia",
                column: "OcorrenciaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlteracaoOcorrencia_OcorrenciaId",
                table: "AlteracaoOcorrencia");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoOcorrenciaId",
                table: "Ocorrencia");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoOcorrencia_OcorrenciaId",
                table: "AlteracaoOcorrencia",
                column: "OcorrenciaId");
        }
    }
}
