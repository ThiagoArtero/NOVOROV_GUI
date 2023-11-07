using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddGestorToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "Usuario",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gestor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGestor = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_GestorId",
                table: "Usuario",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Gestor_GestorId",
                table: "Usuario",
                column: "GestorId",
                principalTable: "Gestor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Gestor_GestorId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Gestor");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_GestorId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Usuario");
        }
    }
}
