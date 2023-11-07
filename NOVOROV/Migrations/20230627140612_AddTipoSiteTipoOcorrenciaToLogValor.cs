using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoSiteTipoOcorrenciaToLogValor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoOcorrenciaId",
                table: "LogValor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoSiteId",
                table: "LogValor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogValor_TipoOcorrenciaId",
                table: "LogValor",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogValor_TipoSiteId",
                table: "LogValor",
                column: "TipoSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogValor_TipoOcorrencia_TipoOcorrenciaId",
                table: "LogValor",
                column: "TipoOcorrenciaId",
                principalTable: "TipoOcorrencia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogValor_TipoSite_TipoSiteId",
                table: "LogValor",
                column: "TipoSiteId",
                principalTable: "TipoSite",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogValor_TipoOcorrencia_TipoOcorrenciaId",
                table: "LogValor");

            migrationBuilder.DropForeignKey(
                name: "FK_LogValor_TipoSite_TipoSiteId",
                table: "LogValor");

            migrationBuilder.DropIndex(
                name: "IX_LogValor_TipoOcorrenciaId",
                table: "LogValor");

            migrationBuilder.DropIndex(
                name: "IX_LogValor_TipoSiteId",
                table: "LogValor");

            migrationBuilder.DropColumn(
                name: "TipoOcorrenciaId",
                table: "LogValor");

            migrationBuilder.DropColumn(
                name: "TipoSiteId",
                table: "LogValor");
        }
    }
}
