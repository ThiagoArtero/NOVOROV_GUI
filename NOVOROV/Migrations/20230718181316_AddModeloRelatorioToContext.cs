using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddModeloRelatorioToContext : Migration
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
                name: "TipoRelatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoRelatorio = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRelatorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRelatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeModelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoRelatorioId = table.Column<int>(type: "int", nullable: true),
                    NumeroRov = table.Column<bool>(type: "bit", nullable: true),
                    AcionadoProntoAtendimento = table.Column<bool>(type: "bit", nullable: true),
                    AlarmeRealAcidental = table.Column<bool>(type: "bit", nullable: true),
                    Ambiente = table.Column<bool>(type: "bit", nullable: true),
                    AnaliseConclusao = table.Column<bool>(type: "bit", nullable: true),
                    AreaInterna = table.Column<bool>(type: "bit", nullable: true),
                    AreaSaude = table.Column<bool>(type: "bit", nullable: true),
                    AreaTratamento = table.Column<bool>(type: "bit", nullable: true),
                    AtendeuSla = table.Column<bool>(type: "bit", nullable: true),
                    BombeiroCivil = table.Column<bool>(type: "bit", nullable: true),
                    CargoFuncao = table.Column<bool>(type: "bit", nullable: true),
                    CEP = table.Column<bool>(type: "bit", nullable: true),
                    Cmc = table.Column<bool>(type: "bit", nullable: true),
                    CodigoSinistro = table.Column<bool>(type: "bit", nullable: true),
                    Conclusao = table.Column<bool>(type: "bit", nullable: true),
                    Condutor = table.Column<bool>(type: "bit", nullable: true),
                    DataConclusao = table.Column<bool>(type: "bit", nullable: true),
                    DataConclusaoChamado = table.Column<bool>(type: "bit", nullable: true),
                    DataOcorrencia = table.Column<bool>(type: "bit", nullable: true),
                    DataConclusaoSis = table.Column<bool>(type: "bit", nullable: true),
                    DataReagendamentoSis = table.Column<bool>(type: "bit", nullable: true),
                    DataRegistro = table.Column<bool>(type: "bit", nullable: true),
                    Detentora = table.Column<bool>(type: "bit", nullable: true),
                    DiasConclusao = table.Column<bool>(type: "bit", nullable: true),
                    EmSeguimento = table.Column<bool>(type: "bit", nullable: true),
                    Empresa = table.Column<bool>(type: "bit", nullable: true),
                    Endereco = table.Column<bool>(type: "bit", nullable: true),
                    EventoErb = table.Column<bool>(type: "bit", nullable: true),
                    Historico = table.Column<bool>(type: "bit", nullable: true),
                    Inbox = table.Column<bool>(type: "bit", nullable: true),
                    InformacaoComplementar = table.Column<bool>(type: "bit", nullable: true),
                    Local = table.Column<bool>(type: "bit", nullable: true),
                    Manutencao = table.Column<bool>(type: "bit", nullable: true),
                    Municipio = table.Column<bool>(type: "bit", nullable: true),
                    NomeSite = table.Column<bool>(type: "bit", nullable: true),
                    Placa = table.Column<bool>(type: "bit", nullable: true),
                    Qualificacao = table.Column<bool>(type: "bit", nullable: true),
                    ResponsavelOperacional = table.Column<bool>(type: "bit", nullable: true),
                    Seguimento = table.Column<bool>(type: "bit", nullable: true),
                    SistemaFechaduraBluetooth = table.Column<bool>(type: "bit", nullable: true),
                    SistemaRastreamento = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    TipoAlarme = table.Column<bool>(type: "bit", nullable: true),
                    TipoSite = table.Column<bool>(type: "bit", nullable: true),
                    TipoOcorrencia = table.Column<bool>(type: "bit", nullable: true),
                    Transportadora = table.Column<bool>(type: "bit", nullable: true),
                    Observacao = table.Column<bool>(type: "bit", nullable: true),
                    UF = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioAlteracaoOcorrencia = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRelatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRelatorio_TipoRelatorio_TipoRelatorioId",
                        column: x => x.TipoRelatorioId,
                        principalTable: "TipoRelatorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRelatorio_TipoRelatorioId",
                table: "ModeloRelatorio",
                column: "TipoRelatorioId");

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
                name: "ModeloRelatorio");

            migrationBuilder.DropTable(
                name: "TipoRelatorio");

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
