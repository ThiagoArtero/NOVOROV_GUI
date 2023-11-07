using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSeguimentoFromOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Seguimento_SeguimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SeguimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "SeguimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "SeguimentolId",
                table: "Ocorrencia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeguimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeguimentolId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SeguimentoId",
                table: "Ocorrencia",
                column: "SeguimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Seguimento_SeguimentoId",
                table: "Ocorrencia",
                column: "SeguimentoId",
                principalTable: "Seguimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
