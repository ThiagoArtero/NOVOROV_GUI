using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddAnexoAndDataToAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Bytes",
                table: "Atendimento",
                type: "varbinary(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Atendimento",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtendimento",
                table: "Atendimento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeAnexoAtendimento",
                table: "Atendimento",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRespostaId",
                table: "Atendimento",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_UsuarioRespostaId",
                table: "Atendimento",
                column: "UsuarioRespostaId");


            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioRespostaId",
                table: "Atendimento",
                column: "UsuarioRespostaId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Usuario_UsuarioRespostaId",
                table: "Atendimento");


            migrationBuilder.DropIndex(
                name: "IX_Atendimento_UsuarioRespostaId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "DataAtendimento",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "NomeAnexoAtendimento",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "UsuarioRespostaId",
                table: "Atendimento");
        }
    }
}
