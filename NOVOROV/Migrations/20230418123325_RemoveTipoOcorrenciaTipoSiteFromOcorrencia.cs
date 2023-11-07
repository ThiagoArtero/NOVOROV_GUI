using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTipoOcorrenciaTipoSiteFromOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoOcorrenciaTipoSite_Ocorrencia_OcorrenciaId",
                table: "TipoOcorrenciaTipoSite");

            migrationBuilder.DropIndex(
                name: "IX_TipoOcorrenciaTipoSite_OcorrenciaId",
                table: "TipoOcorrenciaTipoSite");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "TipoOcorrenciaTipoSite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "TipoOcorrenciaTipoSite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoOcorrenciaTipoSite_OcorrenciaId",
                table: "TipoOcorrenciaTipoSite",
                column: "OcorrenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoOcorrenciaTipoSite_Ocorrencia_OcorrenciaId",
                table: "TipoOcorrenciaTipoSite",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id");
        }
    }
}
