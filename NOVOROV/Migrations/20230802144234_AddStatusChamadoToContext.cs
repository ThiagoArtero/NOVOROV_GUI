using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusChamadoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusChamadoId",
                table: "Chamado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusChamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStatusChamado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusChamado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_StatusChamadoId",
                table: "Chamado",
                column: "StatusChamadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_StatusChamado_StatusChamadoId",
                table: "Chamado",
                column: "StatusChamadoId",
                principalTable: "StatusChamado",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_StatusChamado_StatusChamadoId",
                table: "Chamado");

            migrationBuilder.DropTable(
                name: "StatusChamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_StatusChamadoId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "StatusChamadoId",
                table: "Chamado");
        }
    }
}
