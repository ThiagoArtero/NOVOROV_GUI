using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");
        }
    }
}
