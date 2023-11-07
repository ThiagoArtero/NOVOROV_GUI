using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Site_SistemaRastreamento_SistemaRastrementoId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Site");

            migrationBuilder.RenameColumn(
                name: "SistemaRastremetoId",
                table: "Site",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "SistemaRastrementoId",
                table: "Site",
                newName: "SistemaRastreamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_SistemaRastrementoId",
                table: "Site",
                newName: "IX_Site_SistemaRastreamentoId");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Ocorrencia",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Site_StatusId",
                table: "Site",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_SistemaRastreamento_SistemaRastreamentoId",
                table: "Site",
                column: "SistemaRastreamentoId",
                principalTable: "SistemaRastreamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Status_StatusId",
                table: "Site",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Site_SistemaRastreamento_SistemaRastreamentoId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Status_StatusId",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_StatusId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Ocorrencia");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Site",
                newName: "SistemaRastremetoId");

            migrationBuilder.RenameColumn(
                name: "SistemaRastreamentoId",
                table: "Site",
                newName: "SistemaRastrementoId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_SistemaRastreamentoId",
                table: "Site",
                newName: "IX_Site_SistemaRastrementoId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Site",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_SistemaRastreamento_SistemaRastrementoId",
                table: "Site",
                column: "SistemaRastrementoId",
                principalTable: "SistemaRastreamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
