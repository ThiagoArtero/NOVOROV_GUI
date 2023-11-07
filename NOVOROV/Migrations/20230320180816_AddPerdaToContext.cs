using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddPerdaToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroBOSinistroRede = table.Column<string>(type: "varchar(20)", nullable: true),
                    QuantidadePerda = table.Column<int>(type: "int", nullable: true),
                    CodigoSinistro = table.Column<string>(type: "varchar(50)", nullable: true),
                    ValorPerda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorEfetivamenteRecuperado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorPerdaEvitada = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perda_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perda_OcorrenciaId",
                table: "Perda",
                column: "OcorrenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perda");
        }
    }
}
