using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoEquipamentoToPerda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEquipamentoId",
                table: "Perda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Perda_TipoEquipamentoId",
                table: "Perda",
                column: "TipoEquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perda_TipoEquipamento_TipoEquipamentoId",
                table: "Perda",
                column: "TipoEquipamentoId",
                principalTable: "TipoEquipamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perda_TipoEquipamento_TipoEquipamentoId",
                table: "Perda");

            migrationBuilder.DropIndex(
                name: "IX_Perda_TipoEquipamentoId",
                table: "Perda");

            migrationBuilder.DropColumn(
                name: "TipoEquipamentoId",
                table: "Perda");
        }
    }
}
