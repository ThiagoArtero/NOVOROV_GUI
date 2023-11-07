using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoOcorrenciaTipoSiteToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoOcorrenciaTipoSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSiteId = table.Column<int>(type: "int", nullable: true),
                    TipoOcorrenciaId = table.Column<int>(type: "int", nullable: true),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcorrenciaTipoSite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoOcorrenciaTipoSite_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TipoOcorrenciaTipoSite_TipoOcorrencia_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TipoOcorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TipoOcorrenciaTipoSite_TipoSite_TipoSiteId",
                        column: x => x.TipoSiteId,
                        principalTable: "TipoSite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoOcorrenciaTipoSite_OcorrenciaId",
                table: "TipoOcorrenciaTipoSite",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoOcorrenciaTipoSite_TipoOcorrenciaId",
                table: "TipoOcorrenciaTipoSite",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoOcorrenciaTipoSite_TipoSiteId",
                table: "TipoOcorrenciaTipoSite",
                column: "TipoSiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoOcorrenciaTipoSite");
        }
    }
}
