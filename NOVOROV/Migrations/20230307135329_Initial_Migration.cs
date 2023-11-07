using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AcionadoProntoAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAcionadoProntoAtendimento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcionadoProntoAtendimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlarmeRealAcidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAlarmeRealAcidente = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmeRealAcidente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnaliseConclusao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnaliseConclusao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseConclusao", x => x.Id);
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
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiglaArea = table.Column<string>(type: "varchar(10)", nullable: false),
                    DescricaoDenominacao = table.Column<string>(type: "varchar(10)", nullable: false),
                    SiglaVp = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaInterna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAreaInterna = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaInterna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaInternaPassivo",
                columns: table => new
                {
                    AreaInternaPassivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAreaInternaPassivoo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaInternaPassivo", x => x.AreaInternaPassivoId);
                });

            migrationBuilder.CreateTable(
                name: "AreaSaude",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAreaSaude = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaSaude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaTratamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAreaTratamento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTratamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoSLA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAtendimentoSLA = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoSLA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BombeiroCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBombeiroCivil = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombeiroCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BombeiroMilitar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBombeiroMilitar = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombeiroMilitar", x => x.Id);
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
                name: "Detentora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDetentora = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaChamadoSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresaChamadoSis = table.Column<string>(type: "varchar(50)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaChamadoSis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaPassivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresaPassivo = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaPassivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaProntoAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresaProntoAtendimento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaProntoAtendimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipamentoSis = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoSis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventoCausa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEventoCausa = table.Column<string>(type: "varchar(50)", nullable: false),
                    Procedimento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Item = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoCausa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventoERB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEventoERB = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoERB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FornecimentoAcessoFisico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecimentoAcessoFisico = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecimentoAcessoFisico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FornecimentoEventoAlarme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecimentoEventoAlarme = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecimentoEventoAlarme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FornecimentoImagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecimentoImagem = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecimentoImagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inbox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInbox = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacaoComplementar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInformacaoComplementar = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoComplementar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocal = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeManutencao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMotivo = table.Column<string>(type: "varchar(50)", nullable: false),
                    DescricaoMotivo = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgaoPublico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOrgaoPublico = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgaoPublico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePerfil = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlaca = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoDeEmergencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlanoDeEmergencia = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeEmergencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeQualificacao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualificacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPolicial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRegistroPolicial = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPolicial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSeguimento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaFechaduraBluetooth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSistemaFechaduraBluetooth = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaFechaduraBluetooth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaRastreamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSistemaRastreamento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaRastreamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaSis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSistemaSis = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaSis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStatus = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoAcesso = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAcesso", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "TipoAnexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoAnexo = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAnexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAuditoria",
                columns: table => new
                {
                    TipoAuditoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoAuditoria = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAuditoria", x => x.TipoAuditoriaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoEquipamento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOcorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoOcorrencia = table.Column<string>(type: "varchar(50)", nullable: false),
                    DescricaoTipoOcorrencia = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcorrencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRessarcimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoRessarcimento = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRessarcimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTransportadora = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtualizacaoOcorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InformanteId = table.Column<int>(type: "int", nullable: false),
                    MotivoId = table.Column<int>(type: "int", nullable: false),
                    NomeFormulario = table.Column<string>(type: "varchar(50)", nullable: false),
                    StatusPrioridade = table.Column<bool>(type: "bit", nullable: false),
                    StatusAtualizacao = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoHistoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoAtualizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroVersaoOcorrencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtualizacaoOcorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtualizacaoOcorrencia_Motivo_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DataInicioAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimAcesso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TelefoneUsuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    NomeGestorVivo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoObservacao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoraOcorrencia = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoraRegistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    CargoFuncao = table.Column<string>(type: "varchar(150)", nullable: false),
                    Outros = table.Column<string>(type: "varchar(150)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ambiente = table.Column<string>(type: "varchar(150)", nullable: false),
                    Indicacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: true),
                    Municipio = table.Column<string>(type: "varchar(80)", nullable: false),
                    StatusSisGarantia = table.Column<bool>(type: "bit", nullable: true),
                    DataPassagem = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataSSMA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRegistroReagendamentoSis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataReagendamentoSis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CmcId = table.Column<int>(type: "int", nullable: false),
                    TipoSiteId = table.Column<int>(type: "int", nullable: false),
                    TipoOcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: true),
                    AreaSaudeId = table.Column<int>(type: "int", nullable: false),
                    ManutencaoId = table.Column<int>(type: "int", nullable: true),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    SeguimentolId = table.Column<int>(type: "int", nullable: true),
                    SeguimentoId = table.Column<int>(type: "int", nullable: true),
                    InboxId = table.Column<int>(type: "int", nullable: false),
                    TipoAcessoId = table.Column<int>(type: "int", nullable: false),
                    AtendimentoSLAId = table.Column<int>(type: "int", nullable: true),
                    RegistroPolicialId = table.Column<int>(type: "int", nullable: true),
                    FornecimentoImagemId = table.Column<int>(type: "int", nullable: true),
                    FornecimentoEventoAlarmeId = table.Column<int>(type: "int", nullable: true),
                    FornecimentoAcessoFisicoId = table.Column<int>(type: "int", nullable: true),
                    EmpresaProntoAtendimentoId = table.Column<int>(type: "int", nullable: true),
                    AcionadoProntoAtendimentoId = table.Column<int>(type: "int", nullable: false),
                    AreaInternaId = table.Column<int>(type: "int", nullable: true),
                    BombeiroCivilId = table.Column<int>(type: "int", nullable: false),
                    BombeiroMilitarId = table.Column<int>(type: "int", nullable: false),
                    PlanoDeEmergenciaId = table.Column<int>(type: "int", nullable: false),
                    OrgaoPublicoId = table.Column<int>(type: "int", nullable: true),
                    CondutorId = table.Column<int>(type: "int", nullable: true),
                    TipoAlarmeId = table.Column<int>(type: "int", nullable: true),
                    AlarmeRealAcidenteId = table.Column<int>(type: "int", nullable: false),
                    EventoERBId = table.Column<int>(type: "int", nullable: false),
                    InformacaoComplementarId = table.Column<int>(type: "int", nullable: false),
                    QualificacaoId = table.Column<int>(type: "int", nullable: false),
                    EventoCausaId = table.Column<int>(type: "int", nullable: false),
                    PlacaId = table.Column<int>(type: "int", nullable: false),
                    EquipamentoSisId = table.Column<int>(type: "int", nullable: false),
                    EmpresaChamadoSisId = table.Column<int>(type: "int", nullable: false),
                    TransportadoraId = table.Column<int>(type: "int", nullable: false),
                    SistemaSisId = table.Column<int>(type: "int", nullable: false),
                    DetentoraId = table.Column<int>(type: "int", nullable: false),
                    UsuarioOperadorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioOperadorUsuarioId = table.Column<string>(type: "varchar(10)", nullable: true),
                    SistemaRastreamentoId = table.Column<int>(type: "int", nullable: false),
                    SistemaFechaduraBluetoothId = table.Column<int>(type: "int", nullable: false),
                    AreaTratamentoId = table.Column<int>(type: "int", nullable: false),
                    AnaliseConclusaoId = table.Column<int>(type: "int", nullable: true),
                    AcaoTomadaId = table.Column<int>(type: "int", nullable: true),
                    ControleId = table.Column<int>(type: "int", nullable: true),
                    AprovacaoPerdaId = table.Column<int>(type: "int", nullable: true),
                    AprovacaoQualidadeId = table.Column<int>(type: "int", nullable: true),
                    Historico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                        column: x => x.AcaoTomadaId,
                        principalTable: "AcaoTomada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AcionadoProntoAtendimento_AcionadoProntoAtendimentoId",
                        column: x => x.AcionadoProntoAtendimentoId,
                        principalTable: "AcionadoProntoAtendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AlarmeRealAcidente_AlarmeRealAcidenteId",
                        column: x => x.AlarmeRealAcidenteId,
                        principalTable: "AlarmeRealAcidente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AnaliseConclusao_AnaliseConclusaoId",
                        column: x => x.AnaliseConclusaoId,
                        principalTable: "AnaliseConclusao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                        column: x => x.AprovacaoPerdaId,
                        principalTable: "AprovacaoPerda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                        column: x => x.AprovacaoQualidadeId,
                        principalTable: "AprovacaoQualidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AreaInterna_AreaInternaId",
                        column: x => x.AreaInternaId,
                        principalTable: "AreaInterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AreaSaude_AreaSaudeId",
                        column: x => x.AreaSaudeId,
                        principalTable: "AreaSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AreaTratamento_AreaTratamentoId",
                        column: x => x.AreaTratamentoId,
                        principalTable: "AreaTratamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_AtendimentoSLA_AtendimentoSLAId",
                        column: x => x.AtendimentoSLAId,
                        principalTable: "AtendimentoSLA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_BombeiroCivil_BombeiroCivilId",
                        column: x => x.BombeiroCivilId,
                        principalTable: "BombeiroCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_BombeiroMilitar_BombeiroMilitarId",
                        column: x => x.BombeiroMilitarId,
                        principalTable: "BombeiroMilitar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Condutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Controle_ControleId",
                        column: x => x.ControleId,
                        principalTable: "Controle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Detentora_DetentoraId",
                        column: x => x.DetentoraId,
                        principalTable: "Detentora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_EmpresaChamadoSis_EmpresaChamadoSisId",
                        column: x => x.EmpresaChamadoSisId,
                        principalTable: "EmpresaChamadoSis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_EmpresaProntoAtendimento_EmpresaProntoAtendimentoId",
                        column: x => x.EmpresaProntoAtendimentoId,
                        principalTable: "EmpresaProntoAtendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_EquipamentoSis_EquipamentoSisId",
                        column: x => x.EquipamentoSisId,
                        principalTable: "EquipamentoSis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                        column: x => x.EventoCausaId,
                        principalTable: "EventoCausa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_EventoERB_EventoERBId",
                        column: x => x.EventoERBId,
                        principalTable: "EventoERB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_FornecimentoAcessoFisico_FornecimentoAcessoFisicoId",
                        column: x => x.FornecimentoAcessoFisicoId,
                        principalTable: "FornecimentoAcessoFisico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_FornecimentoEventoAlarme_FornecimentoEventoAlarmeId",
                        column: x => x.FornecimentoEventoAlarmeId,
                        principalTable: "FornecimentoEventoAlarme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_FornecimentoImagem_FornecimentoImagemId",
                        column: x => x.FornecimentoImagemId,
                        principalTable: "FornecimentoImagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Inbox_InboxId",
                        column: x => x.InboxId,
                        principalTable: "Inbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_InformacaoComplementar_InformacaoComplementarId",
                        column: x => x.InformacaoComplementarId,
                        principalTable: "InformacaoComplementar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Manutencao_ManutencaoId",
                        column: x => x.ManutencaoId,
                        principalTable: "Manutencao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_OrgaoPublico_OrgaoPublicoId",
                        column: x => x.OrgaoPublicoId,
                        principalTable: "OrgaoPublico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Placa_PlacaId",
                        column: x => x.PlacaId,
                        principalTable: "Placa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_PlanoDeEmergencia_PlanoDeEmergenciaId",
                        column: x => x.PlanoDeEmergenciaId,
                        principalTable: "PlanoDeEmergencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Qualificacao_QualificacaoId",
                        column: x => x.QualificacaoId,
                        principalTable: "Qualificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_RegistroPolicial_RegistroPolicialId",
                        column: x => x.RegistroPolicialId,
                        principalTable: "RegistroPolicial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Seguimento_SeguimentoId",
                        column: x => x.SeguimentoId,
                        principalTable: "Seguimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                        column: x => x.SistemaFechaduraBluetoothId,
                        principalTable: "SistemaFechaduraBluetooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_SistemaRastreamento_SistemaRastreamentoId",
                        column: x => x.SistemaRastreamentoId,
                        principalTable: "SistemaRastreamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_SistemaSis_SistemaSisId",
                        column: x => x.SistemaSisId,
                        principalTable: "SistemaSis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_TipoAcesso_TipoAcessoId",
                        column: x => x.TipoAcessoId,
                        principalTable: "TipoAcesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                        column: x => x.TipoAlarmeId,
                        principalTable: "TipoAlarme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_TipoOcorrencia_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TipoOcorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Usuario_UsuarioOperadorUsuarioId",
                        column: x => x.UsuarioOperadorUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "AlteracaoOcorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    IPUsuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    NomeHost = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeCampo = table.Column<string>(type: "varchar(50)", nullable: false),
                    ConteudoAtual = table.Column<string>(type: "varchar(200)", nullable: false),
                    ConteudoAnterior = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlteracaoOcorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlteracaoOcorrencia_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlteracaoOcorrencia_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnexo = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataAnexo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    AutorUsuarioId = table.Column<string>(type: "varchar(10)", nullable: true),
                    DescricaoAnexo = table.Column<string>(type: "varchar(300)", nullable: false),
                    TipoAnexoId = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bytes = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    NumeroVersaoAnexo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexo_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anexo_TipoAnexo_TipoAnexoId",
                        column: x => x.TipoAnexoId,
                        principalTable: "TipoAnexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anexo_Usuario_AutorUsuarioId",
                        column: x => x.AutorUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaDano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    TipoEquipamentoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorDano = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecuperado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAuditoriaDano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Controle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaDano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaDano_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaDano_TipoEquipamento_TipoEquipamentoId",
                        column: x => x.TipoEquipamentoId,
                        principalTable: "TipoEquipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaInfrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Reincidencia = table.Column<bool>(type: "bit", nullable: false),
                    AcaoTomadaId = table.Column<int>(type: "int", nullable: false),
                    Justificativa = table.Column<string>(type: "varchar(255)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaInfrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaInfrator_AcaoTomada_AcaoTomadaId",
                        column: x => x.AcaoTomadaId,
                        principalTable: "AcaoTomada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaInfrator_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditoriaInfrator_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cmc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCmc = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nucleo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cmc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cmc_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDano = table.Column<string>(type: "varchar(40)", nullable: false),
                    NumeroAntigo = table.Column<int>(type: "int", nullable: false),
                    QuantidadeEquipamento = table.Column<int>(type: "int", nullable: false),
                    ValorDano = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecuperado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorEvitado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRecuperado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEvitado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TipoEquipamentoId = table.Column<int>(type: "int", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dano_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dano_TipoEquipamento_TipoEquipamentoId",
                        column: x => x.TipoEquipamentoId,
                        principalTable: "TipoEquipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoSite = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoSite_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false),
                    NomeSite = table.Column<string>(type: "varchar(200)", nullable: false),
                    DDD = table.Column<string>(type: "varchar(10)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    CEPSite = table.Column<string>(type: "varchar(20)", nullable: false),
                    Municipio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Regional = table.Column<string>(type: "varchar(15)", nullable: false),
                    Regiao = table.Column<string>(type: "varchar(15)", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    TipoTecnologia = table.Column<string>(type: "varchar(20)", nullable: false),
                    SistemaRastremetoId = table.Column<int>(type: "int", nullable: false),
                    SistemaRastrementoId = table.Column<int>(type: "int", nullable: false),
                    SistemaFechaduraBluetoothId = table.Column<int>(type: "int", nullable: false),
                    CmcId = table.Column<int>(type: "int", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Site_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                        column: x => x.SistemaFechaduraBluetoothId,
                        principalTable: "SistemaFechaduraBluetooth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_SistemaRastreamento_SistemaRastrementoId",
                        column: x => x.SistemaRastrementoId,
                        principalTable: "SistemaRastreamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Site_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaRecuperacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanoId = table.Column<int>(type: "int", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    ValorPassivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecuperadoPassivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Empresa = table.Column<string>(type: "varchar(50)", nullable: false),
                    QualificacaoId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DataAuditoriaRecuperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(10)", nullable: false),
                    TipoAuditoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaRecuperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_Dano_DanoId",
                        column: x => x.DanoId,
                        principalTable: "Dano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_Qualificacao_QualificacaoId",
                        column: x => x.QualificacaoId,
                        principalTable: "Qualificacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_TipoAuditoria_TipoAuditoriaId",
                        column: x => x.TipoAuditoriaId,
                        principalTable: "TipoAuditoria",
                        principalColumn: "TipoAuditoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriaRecuperacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recuperacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanoId = table.Column<int>(type: "int", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "int", nullable: false),
                    NumeroAntigo = table.Column<int>(type: "int", nullable: false),
                    Passivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorRecuperadoPassivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmpresaPassivoId = table.Column<int>(type: "int", nullable: false),
                    QualificacaoId = table.Column<int>(type: "int", nullable: false),
                    DataRecuperacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorEvitado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoRessarcimentoId = table.Column<int>(type: "int", nullable: false),
                    AreaInternaPassivoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DataValorPassivo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValorRecuperadoPassivo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioValorPassivoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioValorPassivoUsuarioId = table.Column<string>(type: "varchar(10)", nullable: true),
                    UsuarioValorRecuperadoPassivoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioValorRecuperadoPassivoUsuarioId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recuperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recuperacao_AreaInternaPassivo_AreaInternaPassivoId",
                        column: x => x.AreaInternaPassivoId,
                        principalTable: "AreaInternaPassivo",
                        principalColumn: "AreaInternaPassivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recuperacao_Dano_DanoId",
                        column: x => x.DanoId,
                        principalTable: "Dano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recuperacao_EmpresaPassivo_EmpresaPassivoId",
                        column: x => x.EmpresaPassivoId,
                        principalTable: "EmpresaPassivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recuperacao_Ocorrencia_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recuperacao_Qualificacao_QualificacaoId",
                        column: x => x.QualificacaoId,
                        principalTable: "Qualificacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recuperacao_TipoRessarcimento_TipoRessarcimentoId",
                        column: x => x.TipoRessarcimentoId,
                        principalTable: "TipoRessarcimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recuperacao_Usuario_UsuarioValorPassivoUsuarioId",
                        column: x => x.UsuarioValorPassivoUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_Recuperacao_Usuario_UsuarioValorRecuperadoPassivoUsuarioId",
                        column: x => x.UsuarioValorRecuperadoPassivoUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "ApoliceSeguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeApoliceSeguro = table.Column<string>(type: "varchar(50)", nullable: false),
                    DescricaoApoliceSeguro = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValorApoliceSeguro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoSiteId = table.Column<int>(type: "int", nullable: false),
                    TipoOcorrenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApoliceSeguro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApoliceSeguro_TipoOcorrencia_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TipoOcorrencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApoliceSeguro_TipoSite_TipoSiteId",
                        column: x => x.TipoSiteId,
                        principalTable: "TipoSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoPerda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipamentoPerda = table.Column<string>(type: "varchar(50)", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    TipoEquipamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoPerda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentoPerda_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentoPerda_TipoEquipamento_TipoEquipamentoId",
                        column: x => x.TipoEquipamentoId,
                        principalTable: "TipoEquipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoOcorrencia_OcorrenciaId",
                table: "AlteracaoOcorrencia",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlteracaoOcorrencia_UsuarioId",
                table: "AlteracaoOcorrencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_AutorUsuarioId",
                table: "Anexo",
                column: "AutorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_OcorrenciaId",
                table: "Anexo",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anexo_TipoAnexoId",
                table: "Anexo",
                column: "TipoAnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_ApoliceSeguro_TipoOcorrenciaId",
                table: "ApoliceSeguro",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ApoliceSeguro_TipoSiteId",
                table: "ApoliceSeguro",
                column: "TipoSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_AtualizacaoOcorrencia_MotivoId",
                table: "AtualizacaoOcorrencia",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaDano_OcorrenciaId",
                table: "AuditoriaDano",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaDano_TipoEquipamentoId",
                table: "AuditoriaDano",
                column: "TipoEquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaInfrator_AcaoTomadaId",
                table: "AuditoriaInfrator",
                column: "AcaoTomadaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaInfrator_OcorrenciaId",
                table: "AuditoriaInfrator",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaInfrator_UsuarioId",
                table: "AuditoriaInfrator",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_AreaId",
                table: "AuditoriaRecuperacao",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_DanoId",
                table: "AuditoriaRecuperacao",
                column: "DanoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_OcorrenciaId",
                table: "AuditoriaRecuperacao",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_QualificacaoId",
                table: "AuditoriaRecuperacao",
                column: "QualificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_TipoAuditoriaId",
                table: "AuditoriaRecuperacao",
                column: "TipoAuditoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaRecuperacao_UsuarioId",
                table: "AuditoriaRecuperacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cmc_OcorrenciaId",
                table: "Cmc",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dano_OcorrenciaId",
                table: "Dano",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dano_TipoEquipamentoId",
                table: "Dano",
                column: "TipoEquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoPerda_SiteId",
                table: "EquipamentoPerda",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoPerda_TipoEquipamentoId",
                table: "EquipamentoPerda",
                column: "TipoEquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacao_UsuarioId",
                table: "Observacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AcaoTomadaId",
                table: "Ocorrencia",
                column: "AcaoTomadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AcionadoProntoAtendimentoId",
                table: "Ocorrencia",
                column: "AcionadoProntoAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AlarmeRealAcidenteId",
                table: "Ocorrencia",
                column: "AlarmeRealAcidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AnaliseConclusaoId",
                table: "Ocorrencia",
                column: "AnaliseConclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AprovacaoPerdaId",
                table: "Ocorrencia",
                column: "AprovacaoPerdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AprovacaoQualidadeId",
                table: "Ocorrencia",
                column: "AprovacaoQualidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AreaInternaId",
                table: "Ocorrencia",
                column: "AreaInternaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AreaSaudeId",
                table: "Ocorrencia",
                column: "AreaSaudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AreaTratamentoId",
                table: "Ocorrencia",
                column: "AreaTratamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_AtendimentoSLAId",
                table: "Ocorrencia",
                column: "AtendimentoSLAId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_BombeiroCivilId",
                table: "Ocorrencia",
                column: "BombeiroCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_BombeiroMilitarId",
                table: "Ocorrencia",
                column: "BombeiroMilitarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CondutorId",
                table: "Ocorrencia",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_ControleId",
                table: "Ocorrencia",
                column: "ControleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_DetentoraId",
                table: "Ocorrencia",
                column: "DetentoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EmpresaChamadoSisId",
                table: "Ocorrencia",
                column: "EmpresaChamadoSisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EmpresaProntoAtendimentoId",
                table: "Ocorrencia",
                column: "EmpresaProntoAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EquipamentoSisId",
                table: "Ocorrencia",
                column: "EquipamentoSisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EventoCausaId",
                table: "Ocorrencia",
                column: "EventoCausaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EventoERBId",
                table: "Ocorrencia",
                column: "EventoERBId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_FornecimentoAcessoFisicoId",
                table: "Ocorrencia",
                column: "FornecimentoAcessoFisicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_FornecimentoEventoAlarmeId",
                table: "Ocorrencia",
                column: "FornecimentoEventoAlarmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_FornecimentoImagemId",
                table: "Ocorrencia",
                column: "FornecimentoImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_InboxId",
                table: "Ocorrencia",
                column: "InboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_InformacaoComplementarId",
                table: "Ocorrencia",
                column: "InformacaoComplementarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_LocalId",
                table: "Ocorrencia",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_ManutencaoId",
                table: "Ocorrencia",
                column: "ManutencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_OrgaoPublicoId",
                table: "Ocorrencia",
                column: "OrgaoPublicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_PlacaId",
                table: "Ocorrencia",
                column: "PlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_PlanoDeEmergenciaId",
                table: "Ocorrencia",
                column: "PlanoDeEmergenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_QualificacaoId",
                table: "Ocorrencia",
                column: "QualificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_RegistroPolicialId",
                table: "Ocorrencia",
                column: "RegistroPolicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SeguimentoId",
                table: "Ocorrencia",
                column: "SeguimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SistemaFechaduraBluetoothId",
                table: "Ocorrencia",
                column: "SistemaFechaduraBluetoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SistemaRastreamentoId",
                table: "Ocorrencia",
                column: "SistemaRastreamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SistemaSisId",
                table: "Ocorrencia",
                column: "SistemaSisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoAcessoId",
                table: "Ocorrencia",
                column: "TipoAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoAlarmeId",
                table: "Ocorrencia",
                column: "TipoAlarmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoOcorrenciaId",
                table: "Ocorrencia",
                column: "TipoOcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TransportadoraId",
                table: "Ocorrencia",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_UsuarioOperadorUsuarioId",
                table: "Ocorrencia",
                column: "UsuarioOperadorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_AreaInternaPassivoId",
                table: "Recuperacao",
                column: "AreaInternaPassivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_DanoId",
                table: "Recuperacao",
                column: "DanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_EmpresaPassivoId",
                table: "Recuperacao",
                column: "EmpresaPassivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_OcorrenciaId",
                table: "Recuperacao",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_QualificacaoId",
                table: "Recuperacao",
                column: "QualificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_TipoRessarcimentoId",
                table: "Recuperacao",
                column: "TipoRessarcimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_UsuarioValorPassivoUsuarioId",
                table: "Recuperacao",
                column: "UsuarioValorPassivoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Recuperacao_UsuarioValorRecuperadoPassivoUsuarioId",
                table: "Recuperacao",
                column: "UsuarioValorRecuperadoPassivoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CmcId",
                table: "Site",
                column: "CmcId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_OcorrenciaId",
                table: "Site",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_SistemaFechaduraBluetoothId",
                table: "Site",
                column: "SistemaFechaduraBluetoothId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SistemaRastrementoId",
                table: "Site",
                column: "SistemaRastrementoId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_UsuarioId",
                table: "Site",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoSite_OcorrenciaId",
                table: "TipoSite",
                column: "OcorrenciaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlteracaoOcorrencia");

            migrationBuilder.DropTable(
                name: "Anexo");

            migrationBuilder.DropTable(
                name: "ApoliceSeguro");

            migrationBuilder.DropTable(
                name: "AtualizacaoOcorrencia");

            migrationBuilder.DropTable(
                name: "AuditoriaDano");

            migrationBuilder.DropTable(
                name: "AuditoriaInfrator");

            migrationBuilder.DropTable(
                name: "AuditoriaRecuperacao");

            migrationBuilder.DropTable(
                name: "EquipamentoPerda");

            migrationBuilder.DropTable(
                name: "Observacao");

            migrationBuilder.DropTable(
                name: "Recuperacao");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipoAnexo");

            migrationBuilder.DropTable(
                name: "TipoSite");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "TipoAuditoria");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "AreaInternaPassivo");

            migrationBuilder.DropTable(
                name: "Dano");

            migrationBuilder.DropTable(
                name: "EmpresaPassivo");

            migrationBuilder.DropTable(
                name: "TipoRessarcimento");

            migrationBuilder.DropTable(
                name: "Cmc");

            migrationBuilder.DropTable(
                name: "TipoEquipamento");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "AcaoTomada");

            migrationBuilder.DropTable(
                name: "AcionadoProntoAtendimento");

            migrationBuilder.DropTable(
                name: "AlarmeRealAcidente");

            migrationBuilder.DropTable(
                name: "AnaliseConclusao");

            migrationBuilder.DropTable(
                name: "AprovacaoPerda");

            migrationBuilder.DropTable(
                name: "AprovacaoQualidade");

            migrationBuilder.DropTable(
                name: "AreaInterna");

            migrationBuilder.DropTable(
                name: "AreaSaude");

            migrationBuilder.DropTable(
                name: "AreaTratamento");

            migrationBuilder.DropTable(
                name: "AtendimentoSLA");

            migrationBuilder.DropTable(
                name: "BombeiroCivil");

            migrationBuilder.DropTable(
                name: "BombeiroMilitar");

            migrationBuilder.DropTable(
                name: "Condutor");

            migrationBuilder.DropTable(
                name: "Controle");

            migrationBuilder.DropTable(
                name: "Detentora");

            migrationBuilder.DropTable(
                name: "EmpresaChamadoSis");

            migrationBuilder.DropTable(
                name: "EmpresaProntoAtendimento");

            migrationBuilder.DropTable(
                name: "EquipamentoSis");

            migrationBuilder.DropTable(
                name: "EventoCausa");

            migrationBuilder.DropTable(
                name: "EventoERB");

            migrationBuilder.DropTable(
                name: "FornecimentoAcessoFisico");

            migrationBuilder.DropTable(
                name: "FornecimentoEventoAlarme");

            migrationBuilder.DropTable(
                name: "FornecimentoImagem");

            migrationBuilder.DropTable(
                name: "Inbox");

            migrationBuilder.DropTable(
                name: "InformacaoComplementar");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "OrgaoPublico");

            migrationBuilder.DropTable(
                name: "Placa");

            migrationBuilder.DropTable(
                name: "PlanoDeEmergencia");

            migrationBuilder.DropTable(
                name: "Qualificacao");

            migrationBuilder.DropTable(
                name: "RegistroPolicial");

            migrationBuilder.DropTable(
                name: "Seguimento");

            migrationBuilder.DropTable(
                name: "SistemaFechaduraBluetooth");

            migrationBuilder.DropTable(
                name: "SistemaRastreamento");

            migrationBuilder.DropTable(
                name: "SistemaSis");

            migrationBuilder.DropTable(
                name: "TipoAcesso");

            migrationBuilder.DropTable(
                name: "TipoAlarme");

            migrationBuilder.DropTable(
                name: "TipoOcorrencia");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
