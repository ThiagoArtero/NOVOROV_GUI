using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddEspelhoToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Espelho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalistaCriadorId = table.Column<string>(type: "varchar(10)", nullable: true),
                    NomeEspelho = table.Column<string>(type: "varchar(300)", nullable: true),
                    DataEspelho = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEnvioFinanceiro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEnvioAnalise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bytes = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espelho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Espelho_Usuario_AnalistaCriadorId",
                        column: x => x.AnalistaCriadorId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Espelho_AnalistaCriadorId",
                table: "Espelho",
                column: "AnalistaCriadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "Espelho");
        }
    }
}
