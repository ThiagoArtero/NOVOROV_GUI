using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class ExclusaoDeCamposAntigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditoriaInfrator_AcaoTomada_AcaoTomadaId",
                table: "AuditoriaInfrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Condutor_CondutorId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Controle_ControleId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "AcaoTomada");

            migrationBuilder.DropTable(
                name: "AprovacaoPerda");

            migrationBuilder.DropTable(
                name: "AprovacaoQualidade");

            migrationBuilder.DropTable(
                name: "Condutor");

            migrationBuilder.DropTable(
                name: "Controle");

            migrationBuilder.DropTable(
                name: "EventoCausa");

            migrationBuilder.DropTable(
                name: "TipoAlarme");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_AcaoTomadaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_AprovacaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_AprovacaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_CondutorId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_ControleId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_EventoCausaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_PlacaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_TipoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_AuditoriaInfrator_AcaoTomadaId",
                table: "AuditoriaInfrator");

            migrationBuilder.DropColumn(
                name: "AcaoTomadaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "AprovacaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "AprovacaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "CondutorId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "ControleId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "EventoCausaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "PlacaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "TipoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "AcaoTomadaId",
                table: "AuditoriaInfrator");

            migrationBuilder.AddColumn<string>(
                name: "Condutor",
                table: "Ocorrencia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Ocorrencia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoAlarme",
                table: "Ocorrencia",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condutor",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "TipoAlarme",
                table: "Ocorrencia");

            migrationBuilder.AddColumn<int>(
                name: "AcaoTomadaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AprovacaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AprovacaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CondutorId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControleId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoCausaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlacaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoAlarmeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcaoTomadaId",
                table: "AuditoriaInfrator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AcaoTomada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAcaoTomada = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcaoTomada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AprovacaoPerda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAprovacaoPerda = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AprovacaoPerda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AprovacaoQualidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAprovacaoQualidade = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AprovacaoQualidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCondutor = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Controle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeControle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventoCausa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "varchar(255)", nullable: false),
                    NomeEventoCausa = table.Column<string>(type: "varchar(50)", nullable: false),
                    Procedimento = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoCausa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAlarme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoAlarme = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlarme", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AcaoTomadaId",
                table: "Ocorrencia",
                column: "AcaoTomadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AprovacaoPerdaId",
                table: "Ocorrencia",
                column: "AprovacaoPerdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AprovacaoQualidadeId",
                table: "Ocorrencia",
                column: "AprovacaoQualidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CondutorId",
                table: "Ocorrencia",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_ControleId",
                table: "Ocorrencia",
                column: "ControleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EventoCausaId",
                table: "Ocorrencia",
                column: "EventoCausaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_PlacaId",
                table: "Ocorrencia",
                column: "PlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoAlarmeId",
                table: "Ocorrencia",
                column: "TipoAlarmeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaInfrator_AcaoTomadaId",
                table: "AuditoriaInfrator",
                column: "AcaoTomadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditoriaInfrator_AcaoTomada_AcaoTomadaId",
                table: "AuditoriaInfrator",
                column: "AcaoTomadaId",
                principalTable: "AcaoTomada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia",
                column: "AcaoTomadaId",
                principalTable: "AcaoTomada",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                table: "Ocorrencia",
                column: "AprovacaoPerdaId",
                principalTable: "AprovacaoPerda",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                table: "Ocorrencia",
                column: "AprovacaoQualidadeId",
                principalTable: "AprovacaoQualidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Condutor_CondutorId",
                table: "Ocorrencia",
                column: "CondutorId",
                principalTable: "Condutor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Controle_ControleId",
                table: "Ocorrencia",
                column: "ControleId",
                principalTable: "Controle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia",
                column: "EventoCausaId",
                principalTable: "EventoCausa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia",
                column: "PlacaId",
                principalTable: "Placa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia",
                column: "TipoAlarmeId",
                principalTable: "TipoAlarme",
                principalColumn: "Id");
        }
    }
}
