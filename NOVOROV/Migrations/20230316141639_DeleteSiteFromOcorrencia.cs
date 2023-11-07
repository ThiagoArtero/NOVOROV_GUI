using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSiteFromOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipamentoPerda_Site_SiteId",
                table: "EquipamentoPerda");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_EquipamentoPerda_SiteId",
                table: "EquipamentoPerda");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "EquipamentoPerda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "EquipamentoPerda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CmcId = table.Column<int>(type: "int", nullable: false),
                    SistemaFechaduraBluetoothId = table.Column<int>(type: "int", nullable: false),
                    SistemaRastreamentoId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CEPSite = table.Column<string>(type: "varchar(20)", nullable: false),
                    DDD = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeSite = table.Column<string>(type: "varchar(200)", nullable: false),
                    Regiao = table.Column<string>(type: "varchar(15)", nullable: false),
                    Regional = table.Column<string>(type: "varchar(15)", nullable: false),
                    TipoTecnologia = table.Column<string>(type: "varchar(20)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Cmc_CmcId",
                        column: x => x.CmcId,
                        principalTable: "Cmc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                        column: x => x.SistemaFechaduraBluetoothId,
                        principalTable: "SistemaFechaduraBluetooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_SistemaRastreamento_SistemaRastreamentoId",
                        column: x => x.SistemaRastreamentoId,
                        principalTable: "SistemaRastreamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SiteId",
                table: "Ocorrencia",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoPerda_SiteId",
                table: "EquipamentoPerda",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CmcId",
                table: "Site",
                column: "CmcId");

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
                name: "IX_Site_UsuarioId",
                table: "Site",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoPerda_Site_SiteId",
                table: "EquipamentoPerda",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Site_SiteId",
                table: "Ocorrencia",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
