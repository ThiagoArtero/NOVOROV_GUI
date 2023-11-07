using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddChamadoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioOperadorId = table.Column<string>(type: "varchar(10)", nullable: true),
                    SolicitanteId = table.Column<string>(type: "varchar(10)", nullable: true),
                    EmailSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", nullable: true),
                    loja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsavelTrativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContatoResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailResponsavelTratativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solicitacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamado_Usuario_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Chamado_Usuario_UsuarioOperadorId",
                        column: x => x.UsuarioOperadorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_SolicitanteId",
                table: "Chamado",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_UsuarioOperadorId",
                table: "Chamado",
                column: "UsuarioOperadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
