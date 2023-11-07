using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteToContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSiteId = table.Column<int>(type: "int", nullable: true),
                    NomeSite = table.Column<string>(type: "varchar(100)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(15)", nullable: true),
                    SistemaFechaduraBluetoothId = table.Column<int>(type: "int", nullable: true),
                    SistemaRastreamentoId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                        column: x => x.SistemaFechaduraBluetoothId,
                        principalTable: "SistemaFechaduraBluetooth",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Site_SistemaRastreamento_SistemaRastreamentoId",
                        column: x => x.SistemaRastreamentoId,
                        principalTable: "SistemaRastreamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Site_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Site_TipoSite_TipoSiteId",
                        column: x => x.TipoSiteId,
                        principalTable: "TipoSite",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Site_SistemaFechaduraBluetoothId",
                table: "Site",
                column: "SistemaFechaduraBluetoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SistemaRastreamentoId",
                table: "Site",
                column: "SistemaRastreamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_StatusId",
                table: "Site",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_TipoSiteId",
                table: "Site",
                column: "TipoSiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
