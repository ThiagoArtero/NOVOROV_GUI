using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia",
                column: "SiteId");

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
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Ocorrencia");
        }
    }
}
