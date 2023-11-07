using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class NullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Local_LocalId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoAcesso_TipoAcessoId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAcessoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Ocorrencia",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Local_LocalId",
                table: "Ocorrencia",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoAcesso_TipoAcessoId",
                table: "Ocorrencia",
                column: "TipoAcessoId",
                principalTable: "TipoAcesso",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Local_LocalId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoAcesso_TipoAcessoId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAcessoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Ocorrencia",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Local_LocalId",
                table: "Ocorrencia",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoAcesso_TipoAcessoId",
                table: "Ocorrencia",
                column: "TipoAcessoId",
                principalTable: "TipoAcesso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
