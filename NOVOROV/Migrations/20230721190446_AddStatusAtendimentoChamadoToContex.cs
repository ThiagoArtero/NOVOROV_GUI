using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAtendimentoChamadoToContex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusAtendimentoChamadoId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusAtendimentoChamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStatusAtendimento = table.Column<string>(type: "varchar(50)", nullable: true),
                    FuncaoStatusAtendimento = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAtendimentoChamado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_StatusAtendimentoChamadoId",
                table: "Atendimento",
                column: "StatusAtendimentoChamadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_StatusAtendimentoChamado_StatusAtendimentoChamadoId",
                table: "Atendimento",
                column: "StatusAtendimentoChamadoId",
                principalTable: "StatusAtendimentoChamado",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_StatusAtendimentoChamado_StatusAtendimentoChamadoId",
                table: "Atendimento");

            migrationBuilder.DropTable(
                name: "StatusAtendimentoChamado");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_StatusAtendimentoChamadoId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "StatusAtendimentoChamadoId",
                table: "Atendimento");
        }
    }
}
