using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AnularCamposOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AlarmeRealAcidente_AlarmeRealAcidenteId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AnaliseConclusao_AnaliseConclusaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AreaInterna_AreaInternaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AreaTratamento_AreaTratamentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AtendimentoSLA_AtendimentoSLAId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Condutor_CondutorId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Controle_ControleId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Detentora_DetentoraId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EmpresaChamadoSis_EmpresaChamadoSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EmpresaProntoAtendimento_EmpresaProntoAtendimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EquipamentoSis_EquipamentoSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EventoERB_EventoERBId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoAcessoFisico_FornecimentoAcessoFisicoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoEventoAlarme_FornecimentoEventoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoImagem_FornecimentoImagemId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_InformacaoComplementar_InformacaoComplementarId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Manutencao_ManutencaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_OrgaoPublico_OrgaoPublicoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Qualificacao_QualificacaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_RegistroPolicial_RegistroPolicialId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaRastreamento_SistemaRastreamentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaSis_SistemaSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Transportadora_TransportadoraId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioOperadorId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioAlteracaoOcorrenciaId",
                table: "Ocorrencia",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<int>(
                name: "TransportadoraId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TipoAlarmeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "StatusSisGarantia",
                table: "Ocorrencia",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "SistemaSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SistemaRastreamentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SistemaFechaduraBluetoothId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RegistroPolicialId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QualificacaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlacaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrgaoPublicoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ManutencaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InformacaoComplementarId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoImagemId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoEventoAlarmeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoAcessoFisicoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventoERBId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventoCausaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaProntoAtendimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaChamadoSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DetentoraId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ControleId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CondutorId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AtendimentoSLAId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AreaTratamentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AreaInternaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AprovacaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AprovacaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnaliseConclusaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AlarmeRealAcidenteId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AcaoTomadaId",
                table: "Ocorrencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia",
                column: "AcaoTomadaId",
                principalTable: "AcaoTomada",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AlarmeRealAcidente_AlarmeRealAcidenteId",
                table: "Ocorrencia",
                column: "AlarmeRealAcidenteId",
                principalTable: "AlarmeRealAcidente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AnaliseConclusao_AnaliseConclusaoId",
                table: "Ocorrencia",
                column: "AnaliseConclusaoId",
                principalTable: "AnaliseConclusao",
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
                name: "FK_Ocorrencia_AreaInterna_AreaInternaId",
                table: "Ocorrencia",
                column: "AreaInternaId",
                principalTable: "AreaInterna",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AreaTratamento_AreaTratamentoId",
                table: "Ocorrencia",
                column: "AreaTratamentoId",
                principalTable: "AreaTratamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AtendimentoSLA_AtendimentoSLAId",
                table: "Ocorrencia",
                column: "AtendimentoSLAId",
                principalTable: "AtendimentoSLA",
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
                name: "FK_Ocorrencia_Detentora_DetentoraId",
                table: "Ocorrencia",
                column: "DetentoraId",
                principalTable: "Detentora",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EmpresaChamadoSis_EmpresaChamadoSisId",
                table: "Ocorrencia",
                column: "EmpresaChamadoSisId",
                principalTable: "EmpresaChamadoSis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EmpresaProntoAtendimento_EmpresaProntoAtendimentoId",
                table: "Ocorrencia",
                column: "EmpresaProntoAtendimentoId",
                principalTable: "EmpresaProntoAtendimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EquipamentoSis_EquipamentoSisId",
                table: "Ocorrencia",
                column: "EquipamentoSisId",
                principalTable: "EquipamentoSis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia",
                column: "EventoCausaId",
                principalTable: "EventoCausa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EventoERB_EventoERBId",
                table: "Ocorrencia",
                column: "EventoERBId",
                principalTable: "EventoERB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoAcessoFisico_FornecimentoAcessoFisicoId",
                table: "Ocorrencia",
                column: "FornecimentoAcessoFisicoId",
                principalTable: "FornecimentoAcessoFisico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoEventoAlarme_FornecimentoEventoAlarmeId",
                table: "Ocorrencia",
                column: "FornecimentoEventoAlarmeId",
                principalTable: "FornecimentoEventoAlarme",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoImagem_FornecimentoImagemId",
                table: "Ocorrencia",
                column: "FornecimentoImagemId",
                principalTable: "FornecimentoImagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_InformacaoComplementar_InformacaoComplementarId",
                table: "Ocorrencia",
                column: "InformacaoComplementarId",
                principalTable: "InformacaoComplementar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Manutencao_ManutencaoId",
                table: "Ocorrencia",
                column: "ManutencaoId",
                principalTable: "Manutencao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_OrgaoPublico_OrgaoPublicoId",
                table: "Ocorrencia",
                column: "OrgaoPublicoId",
                principalTable: "OrgaoPublico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia",
                column: "PlacaId",
                principalTable: "Placa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Qualificacao_QualificacaoId",
                table: "Ocorrencia",
                column: "QualificacaoId",
                principalTable: "Qualificacao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_RegistroPolicial_RegistroPolicialId",
                table: "Ocorrencia",
                column: "RegistroPolicialId",
                principalTable: "RegistroPolicial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                table: "Ocorrencia",
                column: "SistemaFechaduraBluetoothId",
                principalTable: "SistemaFechaduraBluetooth",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaRastreamento_SistemaRastreamentoId",
                table: "Ocorrencia",
                column: "SistemaRastreamentoId",
                principalTable: "SistemaRastreamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaSis_SistemaSisId",
                table: "Ocorrencia",
                column: "SistemaSisId",
                principalTable: "SistemaSis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia",
                column: "TipoAlarmeId",
                principalTable: "TipoAlarme",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Transportadora_TransportadoraId",
                table: "Ocorrencia",
                column: "TransportadoraId",
                principalTable: "Transportadora",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AlarmeRealAcidente_AlarmeRealAcidenteId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AnaliseConclusao_AnaliseConclusaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AreaInterna_AreaInternaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AreaTratamento_AreaTratamentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_AtendimentoSLA_AtendimentoSLAId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Condutor_CondutorId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Controle_ControleId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Detentora_DetentoraId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EmpresaChamadoSis_EmpresaChamadoSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EmpresaProntoAtendimento_EmpresaProntoAtendimentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EquipamentoSis_EquipamentoSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_EventoERB_EventoERBId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoAcessoFisico_FornecimentoAcessoFisicoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoEventoAlarme_FornecimentoEventoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_FornecimentoImagem_FornecimentoImagemId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_InformacaoComplementar_InformacaoComplementarId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Manutencao_ManutencaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_OrgaoPublico_OrgaoPublicoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Qualificacao_QualificacaoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_RegistroPolicial_RegistroPolicialId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaRastreamento_SistemaRastreamentoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_SistemaSis_SistemaSisId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Transportadora_TransportadoraId",
                table: "Ocorrencia");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioOperadorId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioAlteracaoOcorrenciaId",
                table: "Ocorrencia",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransportadoraId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoAlarmeId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "StatusSisGarantia",
                table: "Ocorrencia",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SistemaSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SistemaRastreamentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SistemaFechaduraBluetoothId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegistroPolicialId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QualificacaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlacaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrgaoPublicoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManutencaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InformacaoComplementarId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoImagemId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoEventoAlarmeId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FornecimentoAcessoFisicoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventoERBId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventoCausaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaProntoAtendimentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaChamadoSisId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DetentoraId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ControleId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CondutorId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtendimentoSLAId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaTratamentoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaInternaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AprovacaoQualidadeId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AprovacaoPerdaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnaliseConclusaoId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlarmeRealAcidenteId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcaoTomadaId",
                table: "Ocorrencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AcaoTomada_AcaoTomadaId",
                table: "Ocorrencia",
                column: "AcaoTomadaId",
                principalTable: "AcaoTomada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AlarmeRealAcidente_AlarmeRealAcidenteId",
                table: "Ocorrencia",
                column: "AlarmeRealAcidenteId",
                principalTable: "AlarmeRealAcidente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AnaliseConclusao_AnaliseConclusaoId",
                table: "Ocorrencia",
                column: "AnaliseConclusaoId",
                principalTable: "AnaliseConclusao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AprovacaoPerda_AprovacaoPerdaId",
                table: "Ocorrencia",
                column: "AprovacaoPerdaId",
                principalTable: "AprovacaoPerda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AprovacaoQualidade_AprovacaoQualidadeId",
                table: "Ocorrencia",
                column: "AprovacaoQualidadeId",
                principalTable: "AprovacaoQualidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AreaInterna_AreaInternaId",
                table: "Ocorrencia",
                column: "AreaInternaId",
                principalTable: "AreaInterna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AreaTratamento_AreaTratamentoId",
                table: "Ocorrencia",
                column: "AreaTratamentoId",
                principalTable: "AreaTratamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_AtendimentoSLA_AtendimentoSLAId",
                table: "Ocorrencia",
                column: "AtendimentoSLAId",
                principalTable: "AtendimentoSLA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Condutor_CondutorId",
                table: "Ocorrencia",
                column: "CondutorId",
                principalTable: "Condutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Controle_ControleId",
                table: "Ocorrencia",
                column: "ControleId",
                principalTable: "Controle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Detentora_DetentoraId",
                table: "Ocorrencia",
                column: "DetentoraId",
                principalTable: "Detentora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EmpresaChamadoSis_EmpresaChamadoSisId",
                table: "Ocorrencia",
                column: "EmpresaChamadoSisId",
                principalTable: "EmpresaChamadoSis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EmpresaProntoAtendimento_EmpresaProntoAtendimentoId",
                table: "Ocorrencia",
                column: "EmpresaProntoAtendimentoId",
                principalTable: "EmpresaProntoAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Empresa_EmpresaId",
                table: "Ocorrencia",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EquipamentoSis_EquipamentoSisId",
                table: "Ocorrencia",
                column: "EquipamentoSisId",
                principalTable: "EquipamentoSis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EventoCausa_EventoCausaId",
                table: "Ocorrencia",
                column: "EventoCausaId",
                principalTable: "EventoCausa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_EventoERB_EventoERBId",
                table: "Ocorrencia",
                column: "EventoERBId",
                principalTable: "EventoERB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoAcessoFisico_FornecimentoAcessoFisicoId",
                table: "Ocorrencia",
                column: "FornecimentoAcessoFisicoId",
                principalTable: "FornecimentoAcessoFisico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoEventoAlarme_FornecimentoEventoAlarmeId",
                table: "Ocorrencia",
                column: "FornecimentoEventoAlarmeId",
                principalTable: "FornecimentoEventoAlarme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_FornecimentoImagem_FornecimentoImagemId",
                table: "Ocorrencia",
                column: "FornecimentoImagemId",
                principalTable: "FornecimentoImagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_InformacaoComplementar_InformacaoComplementarId",
                table: "Ocorrencia",
                column: "InformacaoComplementarId",
                principalTable: "InformacaoComplementar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Manutencao_ManutencaoId",
                table: "Ocorrencia",
                column: "ManutencaoId",
                principalTable: "Manutencao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_OrgaoPublico_OrgaoPublicoId",
                table: "Ocorrencia",
                column: "OrgaoPublicoId",
                principalTable: "OrgaoPublico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Placa_PlacaId",
                table: "Ocorrencia",
                column: "PlacaId",
                principalTable: "Placa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Qualificacao_QualificacaoId",
                table: "Ocorrencia",
                column: "QualificacaoId",
                principalTable: "Qualificacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_RegistroPolicial_RegistroPolicialId",
                table: "Ocorrencia",
                column: "RegistroPolicialId",
                principalTable: "RegistroPolicial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaFechaduraBluetooth_SistemaFechaduraBluetoothId",
                table: "Ocorrencia",
                column: "SistemaFechaduraBluetoothId",
                principalTable: "SistemaFechaduraBluetooth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaRastreamento_SistemaRastreamentoId",
                table: "Ocorrencia",
                column: "SistemaRastreamentoId",
                principalTable: "SistemaRastreamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_SistemaSis_SistemaSisId",
                table: "Ocorrencia",
                column: "SistemaSisId",
                principalTable: "SistemaSis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoAlarme_TipoAlarmeId",
                table: "Ocorrencia",
                column: "TipoAlarmeId",
                principalTable: "TipoAlarme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Transportadora_TransportadoraId",
                table: "Ocorrencia",
                column: "TransportadoraId",
                principalTable: "Transportadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
