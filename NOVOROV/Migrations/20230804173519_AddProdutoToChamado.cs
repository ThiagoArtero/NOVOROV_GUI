using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoToChamado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "AnexosChamado",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "AnexosChamado",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "AnexosChamado",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantidade",
                table: "AnexosChamado",
                type: "varchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "AnexosChamado");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "AnexosChamado");

            migrationBuilder.DropColumn(
                name: "Produto",
                table: "AnexosChamado");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "AnexosChamado");
        }
    }
}
