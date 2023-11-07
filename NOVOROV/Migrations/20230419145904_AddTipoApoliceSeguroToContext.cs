using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoApoliceSeguroToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeApoliceSeguro",
                table: "ApoliceSeguro");

            migrationBuilder.AddColumn<int>(
                name: "TipoApoliceSeguroId",
                table: "ApoliceSeguro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoApoliceSeguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoApoliceSeguro = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoApoliceSeguro", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApoliceSeguro_TipoApoliceSeguroId",
                table: "ApoliceSeguro",
                column: "TipoApoliceSeguroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApoliceSeguro_TipoApoliceSeguro_TipoApoliceSeguroId",
                table: "ApoliceSeguro",
                column: "TipoApoliceSeguroId",
                principalTable: "TipoApoliceSeguro",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApoliceSeguro_TipoApoliceSeguro_TipoApoliceSeguroId",
                table: "ApoliceSeguro");

            migrationBuilder.DropTable(
                name: "TipoApoliceSeguro");

            migrationBuilder.DropIndex(
                name: "IX_ApoliceSeguro_TipoApoliceSeguroId",
                table: "ApoliceSeguro");

            migrationBuilder.DropColumn(
                name: "TipoApoliceSeguroId",
                table: "ApoliceSeguro");

            migrationBuilder.AddColumn<string>(
                name: "NomeApoliceSeguro",
                table: "ApoliceSeguro",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
