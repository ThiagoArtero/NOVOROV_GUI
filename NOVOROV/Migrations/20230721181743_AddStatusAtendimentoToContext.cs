using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAtendimentoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChamadoId = table.Column<int>(type: "int", nullable: true),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "Chamado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_ChamadoId",
                table: "Atendimento",
                column: "ChamadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");
        }
    }
}
