using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionOcorrenciaToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cmc_Ocorrencia_OcorrenciaId",
                table: "Cmc");

            migrationBuilder.DropForeignKey(
                name: "FK_Recuperacao_Usuario_UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Ocorrencia_OcorrenciaId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_OcorrenciaId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Recuperacao_UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao");

            migrationBuilder.DropIndex(
                name: "IX_Cmc_OcorrenciaId",
                table: "Cmc");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "UsuarioValorRecuperadoPassivoId",
                table: "Recuperacao");

            migrationBuilder.DropColumn(
                name: "UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "Cmc");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CmcId",
                table: "Ocorrencia",
                column: "CmcId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Cmc_CmcId",
                table: "Ocorrencia",
                column: "CmcId",
                principalTable: "Cmc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Cmc_CmcId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_CmcId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "Site",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioValorRecuperadoPassivoId",
                table: "Recuperacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "Cmc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Site_OcorrenciaId",
                table: "Site",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao",
                column: "UsuarioValorRecuperadoPassivoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cmc_OcorrenciaId",
                table: "Cmc",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cmc_Ocorrencia_OcorrenciaId",
                table: "Cmc",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recuperacao_Usuario_UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao",
                column: "UsuarioValorRecuperadoPassivoUsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Ocorrencia_OcorrenciaId",
                table: "Site",
                column: "OcorrenciaId",
                principalTable: "Ocorrencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
