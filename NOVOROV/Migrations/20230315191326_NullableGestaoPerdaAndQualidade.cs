using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class NullableGestaoPerdaAndQualidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "GestaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GestaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia",
                column: "GestaoPerdaId",
                principalTable: "GestaoPerda",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia",
                column: "GestaoQualidadeId",
                principalTable: "GestaoQualidade",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "GestaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GestaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoPerda_GestaoPerdaId",
                table: "Ocorrencia",
                column: "GestaoPerdaId",
                principalTable: "GestaoPerda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_GestaoQualidade_GestaoQualidadeId",
                table: "Ocorrencia",
                column: "GestaoQualidadeId",
                principalTable: "GestaoQualidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
