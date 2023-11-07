using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAtendimentoChamdoIdToAtendimentoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoStatusAtendimentoChamado");

            migrationBuilder.AddColumn<int>(
                name: "StatusAtendimentoChamadoId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_StatusAtendimentoChamadoId",
                table: "Atendimento",
                column: "StatusAtendimentoChamadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_StatusAtendimentoChamado_StatusAtendimentoChamadoId",
                table: "Atendimento",
                column: "StatusAtendimentoChamadoId",
                principalTable: "StatusAtendimentoChamado",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_StatusAtendimentoChamado_StatusAtendimentoChamadoId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_StatusAtendimentoChamadoId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "StatusAtendimentoChamadoId",
                table: "Atendimento");

            migrationBuilder.CreateTable(
                name: "AtendimentoStatusAtendimentoChamado",
                columns: table => new
                {
                    AtendimentosId = table.Column<int>(type: "int", nullable: false),
                    StatusAtendimentoChamadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoStatusAtendimentoChamado", x => new { x.AtendimentosId, x.StatusAtendimentoChamadoId });
                    table.ForeignKey(
                        name: "FK_AtendimentoStatusAtendimentoChamado_Atendimento_AtendimentosId",
                        column: x => x.AtendimentosId,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoStatusAtendimentoChamado_StatusAtendimentoChamado_StatusAtendimentoChamadoId",
                        column: x => x.StatusAtendimentoChamadoId,
                        principalTable: "StatusAtendimentoChamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoStatusAtendimentoChamado_StatusAtendimentoChamadoId",
                table: "AtendimentoStatusAtendimentoChamado",
                column: "StatusAtendimentoChamadoId");
        }
    }
}
