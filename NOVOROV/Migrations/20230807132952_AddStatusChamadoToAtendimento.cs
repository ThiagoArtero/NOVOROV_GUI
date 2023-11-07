using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusChamadoToAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusChamadoId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_StatusChamadoId",
                table: "Atendimento",
                column: "StatusChamadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_StatusChamado_StatusChamadoId",
                table: "Atendimento",
                column: "StatusChamadoId",
                principalTable: "StatusChamado",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_StatusChamado_StatusChamadoId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_StatusChamadoId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "StatusChamadoId",
                table: "Atendimento");
        }
    }
}
