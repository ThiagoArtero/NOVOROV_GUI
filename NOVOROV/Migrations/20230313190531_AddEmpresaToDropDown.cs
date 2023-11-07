using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpresaToDropDown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EmpresaId",
                table: "Ocorrencia",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_EmpresaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Ocorrencia",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
