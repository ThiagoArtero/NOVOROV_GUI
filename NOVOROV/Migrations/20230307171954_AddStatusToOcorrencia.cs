using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoSite_Ocorrencia_OcorrenciaId",
                table: "TipoSite");

            migrationBuilder.DropIndex(
                name: "IX_TipoSite_OcorrenciaId",
                table: "TipoSite");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "TipoSite");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_StatusId",
                table: "Ocorrencia",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoSiteId",
                table: "Ocorrencia",
                column: "TipoSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Status_StatusId",
                table: "Ocorrencia",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoSite_TipoSiteId",
                table: "Ocorrencia",
                column: "TipoSiteId",
                principalTable: "TipoSite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Status_StatusId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoSite_TipoSiteId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_StatusId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_TipoSiteId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "TipoSite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoSite_OcorrenciaId",
                table: "TipoSite",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoSite_Ocorrencia_OcorrenciaId",
                table: "TipoSite",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
