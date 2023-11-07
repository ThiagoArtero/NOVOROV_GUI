using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddPassivoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorPassivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorRecuperadoPassivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TipoRessarcimentoId = table.Column<int>(type: "int", nullable: false),
                    AreaInternaId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PerdaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passivo_AreaInterna_AreaInternaId",
                        column: x => x.AreaInternaId,
                        principalTable: "AreaInterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passivo_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passivo_Perda_PerdaId",
                        column: x => x.PerdaId,
                        principalTable: "Perda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passivo_TipoRessarcimento_TipoRessarcimentoId",
                        column: x => x.TipoRessarcimentoId,
                        principalTable: "TipoRessarcimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passivo_AreaInternaId",
                table: "Passivo",
                column: "AreaInternaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passivo_EmpresaId",
                table: "Passivo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passivo_PerdaId",
                table: "Passivo",
                column: "PerdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passivo_TipoRessarcimentoId",
                table: "Passivo",
                column: "TipoRessarcimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passivo");
        }
    }
}
