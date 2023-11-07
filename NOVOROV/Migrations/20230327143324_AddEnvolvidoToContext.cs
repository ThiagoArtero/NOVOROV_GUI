using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddEnvolvidoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcaoTomada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAcaoTomada = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcaoTomada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEnvolvimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoEnvolvimento = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnvolvimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Envolvido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEnvolvido = table.Column<string>(type: "varchar(100)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: true),
                    RG = table.Column<string>(type: "varchar(15)", nullable: true),
                    PlacaVeiculo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Reincidente = table.Column<bool>(type: "bit", nullable: true),
                    Justificativa = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoEnvolvimentoId = table.Column<int>(type: "int", nullable: true),
                    AcaoTomadaId = table.Column<int>(type: "int", nullable: true),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envolvido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envolvido_AcaoTomada_AcaoTomadaId",
                        column: x => x.AcaoTomadaId,
                        principalTable: "AcaoTomada",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Envolvido_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envolvido_TipoEnvolvimento_TipoEnvolvimentoId",
                        column: x => x.TipoEnvolvimentoId,
                        principalTable: "TipoEnvolvimento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envolvido_AcaoTomadaId",
                table: "Envolvido",
                column: "AcaoTomadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envolvido_OcorrenciaId",
                table: "Envolvido",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envolvido_TipoEnvolvimentoId",
                table: "Envolvido",
                column: "TipoEnvolvimentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Envolvido");

            migrationBuilder.DropTable(
                name: "AcaoTomada");

            migrationBuilder.DropTable(
                name: "TipoEnvolvimento");
        }
    }
}
