using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AcionadoProntoAtendimentoNullInOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AcionadoProntoAtendimento_AcionadoProntoAtendimentoId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "AcionadoProntoAtendimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AcionadoProntoAtendimento_AcionadoProntoAtendimentoId",
                table: "Ocorrencia",
                column: "AcionadoProntoAtendimentoId",
                principalTable: "AcionadoProntoAtendimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AcionadoProntoAtendimento_AcionadoProntoAtendimentoId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "AcionadoProntoAtendimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AcionadoProntoAtendimento_AcionadoProntoAtendimentoId",
                table: "Ocorrencia",
                column: "AcionadoProntoAtendimentoId",
                principalTable: "AcionadoProntoAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
