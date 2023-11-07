using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AnularCamposBombeiroInOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_BombeiroCivil_BombeiroCivilId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_BombeiroMilitar_BombeiroMilitarId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_PlanoDeEmergencia_PlanoDeEmergenciaId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "SeguimentolId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlanoDeEmergenciaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BombeiroMilitarId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BombeiroCivilId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_BombeiroCivil_BombeiroCivilId",
                table: "Ocorrencia",
                column: "BombeiroCivilId",
                principalTable: "BombeiroCivil",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_BombeiroMilitar_BombeiroMilitarId",
                table: "Ocorrencia",
                column: "BombeiroMilitarId",
                principalTable: "BombeiroMilitar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_PlanoDeEmergencia_PlanoDeEmergenciaId",
                table: "Ocorrencia",
                column: "PlanoDeEmergenciaId",
                principalTable: "PlanoDeEmergencia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_BombeiroCivil_BombeiroCivilId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_BombeiroMilitar_BombeiroMilitarId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_PlanoDeEmergencia_PlanoDeEmergenciaId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "SeguimentolId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanoDeEmergenciaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BombeiroMilitarId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BombeiroCivilId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_BombeiroCivil_BombeiroCivilId",
                table: "Ocorrencia",
                column: "BombeiroCivilId",
                principalTable: "BombeiroCivil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_BombeiroMilitar_BombeiroMilitarId",
                table: "Ocorrencia",
                column: "BombeiroMilitarId",
                principalTable: "BombeiroMilitar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_PlanoDeEmergencia_PlanoDeEmergenciaId",
                table: "Ocorrencia",
                column: "PlanoDeEmergenciaId",
                principalTable: "PlanoDeEmergencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
