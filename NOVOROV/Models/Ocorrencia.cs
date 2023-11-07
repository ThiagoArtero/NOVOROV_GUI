using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;

namespace NOVOROV.Models
{
    public class Ocorrencia
    {
        [Column(TypeName = "int")]
        [DisplayName("ROV")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("Data Ocorrência")]
        public DateTime? DataOcorrencia { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayName("Hora Ocorrencia")]
        public DateTime? HoraOcorrencia { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayName("Data Registro")]
        public DateTime? DataRegistro { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayName("Hora Registro")]
        public DateTime? HoraRegistro { get; set; }

        [Column(TypeName = "varchar(150)")]
        [DisplayName("Cargo Função")]
        public string? CargoFuncao { get; set; }

        [Column(TypeName = "varchar(150)")]
        [DisplayName("Outros")]
        public string? Outros { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Estado { get; set; }

        [Column(TypeName = "varchar(150)")]
        [DisplayName("Ambiente")]
        public string? Ambiente { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Indicação")]
        public string? Indicacao { get; set; }

        [Column(TypeName = "varchar(150)")]
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [Column(TypeName = "varchar(80)")]
        [DisplayName("Município")]
        public string? Municipio { get; set; }

        [DisplayName("Status Sis Garantia")]
        public bool? StatusSisGarantia { get; set; }

        public DateTime? DataPassagem { get; set; }
        public DateTime? DataSSMA { get; set; }
        public DateTime? DataRegistroReagendamentoSis { get; set; }


        [DisplayName("Cmc")]
        public int? CmcId { get; set; }
        public Cmc? Cmc { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Tipo Site")]
        public int? TipoSiteId { get; set; }
        public TipoSite? TipoSite { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Tipo Ocorrência")]
        public int? TipoOcorrenciaId { get; set; }
        [DisplayName("Tipo Ocorrência")]
        public TipoOcorrencia? TipoOcorrencia { get; set; }

        [DisplayName("Área Saúde")]
        public int? AreaSaudeId { get; set; }
        [DisplayName("Área Saúde")]
        public AreaSaude? AreaSaude { get; set; }


        public int? ManutencaoId { get; set; }
        [DisplayName("Manutenção")]
        public Manutencao? Manutencao { get; set; }

        [DisplayName("Local")]
        public int? LocalId { get; set; }
        [DisplayName("Local")]
        public Local? Local { get; set; }

        [DisplayName("Inbox")]
        public int? InboxId { get; set; }
        public Inbox? Inbox { get; set; }

       

        [DisplayName("Empresa Pronto Atendimento")]
        public int? EmpresaProntoAtendimentoId { get; set; }
        public EmpresaProntoAtendimento? EmpresaProntoAtendimento { get; set; }

        [DisplayName("Acionado Pronto Atendimento")]
        public int? AcionadoProntoAtendimentoId { get; set; }
        public AcionadoProntoAtendimento? AcionadoProntoAtendimento { get; set; }

        [DisplayName("Área Atendimento")]
        public int? AreaInternaId { get; set; }
        public AreaInterna? AreaInterna { get; set; }

        [DisplayName("Bombeiro Civil")]
        public int? BombeiroCivilId { get; set; }
        public BombeiroCivil? BombeiroCivil { get; set; }


        [DisplayName("Bombeiro Militar")]
        public int? BombeiroMilitarId { get; set; }
        public BombeiroMilitar? BombeiroMilitar { get; set; }

        [DisplayName("Plano de Emergência")]
        public int? PlanoDeEmergenciaId { get; set; }
        public PlanoDeEmergencia? PlanoDeEmergencia { get; set; }

        [DisplayName("Órgão Público")]
        public int? OrgaoPublicoId { get; set; }
        public OrgaoPublico? OrgaoPublico { get; set; }

        [DisplayName("Condutor")]
        public string? Condutor { get; set; }

        [DisplayName("Tipo Alarme")]
        public string? TipoAlarme { get; set; }

        [DisplayName("Alarme Real Acidente")]
        public int? AlarmeRealAcidenteId { get; set; }
        [DisplayName("Alarme Real Acidente")]
        public AlarmeRealAcidente? AlarmeRealAcidente{ get; set; }

        [DisplayName("Evento ERB")]
        public int? EventoERBId { get; set; }
        [DisplayName("Evento ERB")]
        public EventoERB? EventoERB { get; set; }

        [DisplayName("Informação Complementar")]
        public int? InformacaoComplementarId { get; set; }
        [DisplayName("Informação Complementar")]
        public InformacaoComplementar? InformacaoComplementar { get; set; }

        [DisplayName("Qualificação")]
        public int? QualificacaoId { get; set; }
        [DisplayName("Qualificação")]
        public Qualificacao? Qualificacao { get; set; }

        [DisplayName("Placa")]
        public string? Placa { get; set; }





        [DisplayName("Transportadora")]
        public int? TransportadoraId { get; set; }
        [DisplayName("Transportadora")]
        public Transportadora? Transportadora { get; set; }



        [DisplayName("Detentora")]
        public int? DetentoraId { get; set; }

        [DisplayName("Detentora")]
        public Detentora? Detentora { get; set; }

        [DisplayName("Usuário Operador")]
        public string? UsuarioOperadorId { get; set; }

        [DisplayName("Usuário Operador")]
        public Usuario? UsuarioOperador { get; set; }

        [DisplayName("Sistema Rastreamento")]
        public int? SistemaRastreamentoId { get; set; }

        [DisplayName("Sistema Rastreamento")]
        public SistemaRastreamento? SistemaRastreamento { get; set; }

        [DisplayName("Sistema Fechadura Bluetooth")]
        public int? SistemaFechaduraBluetoothId { get; set; }

        [DisplayName("Sistema Fechadura Bluetooth")]
        public SistemaFechaduraBluetooth? SistemaFechaduraBluetooth { get; set; }

        [DisplayName("Área Tratamento")]
        public int? AreaTratamentoId { get; set; }

        [DisplayName("Área Tratamento")]
        public AreaTratamento? AreaTratamento { get; set; }

        [DisplayName("Status")]
        public int? StatusId { get; set; }

        [DisplayName("Status")]
        public Status? Status { get; set; }

        [DisplayName("Empresa")]
        public int? EmpresaId { get; set; }

        [DisplayName("Empresa")]
        public Empresa? Empresa { get; set; }

        [DisplayName("Nome do Site")]
        public int? SiteId { get; set; }

        [DisplayName("Nome do Site")]
        public Site? Site { get; set; }

        [DisplayName("Histórico")]
         public string? Historico { get; set; }

        [DisplayName("CEP")]
        [Column(TypeName = "varchar(15)")]
        public string? CEP { get; set; }

        [DisplayName("Informação da Origem")]
        [Column(TypeName = "varchar(50)")]
        public string? InformacaoOrigem { get; set; }

        [DisplayName("Usuário Altereção Ocorrência")]
        [Column(TypeName = "varchar(20)")]
        public string? UsuarioAlteracaoOcorrenciaId { get; set; }

        [DisplayName("Usuário Altereção Ocorrência")]
        public Usuario? UsuarioAlteracaoOcorrencia { get; set; }

        [DisplayName("Endereço")]
        [Column(TypeName = "varchar(100)")]
        public string? Endereco { get; set; }

        [DisplayName("Responsável Operacional")]
        public string? ResponsavelOperacionalId { get; set; }

        //Aba Qualidade
        [Column(TypeName = "datetime")]
        [DisplayName("Data Acionamento Pronto Atendimento")]
        public DateTime? DataAcionamentoProntoAtendimento { get; set; }

        [DisplayName("Gestão de Qualidade")]
        public int? GestaoQualidadeId { get; set; }

        [DisplayName("Gestão de Qualidade")]
        public GestaoQualidade? GestaoQualidade { get; set; }

        [DisplayName("Gestão de Perda")]
        public int? GestaoPerdaId { get; set; }

        [DisplayName("Gestão de Perda")]
        public GestaoPerda? GestaoPerda { get; set; }

        //Aba averiguação
        [Column(TypeName = "datetime")]
        [DisplayName("Data Acionamento Pronto Atendimento")]
        public DateTime? DataInicioAveriguacao { get; set; }

        [DisplayName("Data Conclusão Averiguação")]
        public DateTime? DataConclusaoAveriguacao { get; set; }

        [DisplayName("Dias para Conclusão")]
        public int? DiasConclusao { get; set; }

        [DisplayName("Responsável Averiguação")]
        public string? ResponsavelAveriguacaoId { get; set; }

        [DisplayName("Responsável Averiguação")]
        public Usuario? ResponsavelAveriguacao { get; set; }

        [DisplayName("Conclusão")]
        [Column(TypeName = "varchar(300)")]
        public string? ConclusaoAveriguacao { get; set; }


        //Sistema Sis

        [DisplayName("Sistema")]
        public int? SistemaSisId { get; set; }

        [DisplayName("Sistema")]
        public SistemaSis? SistemaSis { get; set; }

        [DisplayName("Equipamento SIS")]
        public int? EquipamentoSisId { get; set; }

        [DisplayName("Equipamento SIS")]
        public EquipamentoSis? EquipamentoSis { get; set; }

        [DisplayName("Empresa")]
        public int? EmpresaChamadoSisId { get; set; }

        [DisplayName("Empresa")]
        public EmpresaChamadoSis? EmpresaChamadoSis { get; set; }

        [DisplayName("Motivo")]
        [Column(TypeName = "varchar(300)")]
        public string? MotivoSis { get; set; }

        [DisplayName("Número Empresa")]
        [Column(TypeName = "varchar(300)")]
        public int? NumeroEmpresa { get; set; }

        [DisplayName("Data Conclusão")]
        [Column(TypeName = "datetime")]
        public DateTime? DataConclusaoSis { get; set; }

        [DisplayName("Data Reagendamento")]
        [Column(TypeName = "datetime")]
        public DateTime? DataReagendamentoSis { get; set; }

        [DisplayName("Observação")]
        [Column(TypeName = "varchar(500)")]
        public string? ObservacaoSis { get; set; }


        //Tratamento

        [DisplayName("Tipo Acesso")]
        public int? TipoAcessoId { get; set; }

        [DisplayName("Tipo Acesso")]
        public TipoAcesso? TipoAcesso { get; set; }


        [DisplayName("Atendimento SLA")]
        public int? AtendimentoSLAId { get; set; }

        [DisplayName("Atendimento SLA")]
        public AtendimentoSLA? AtendimentoSLA { get; set; }

        [DisplayName("Registro Policial")]
        public int? RegistroPolicialId { get; set; }

        [DisplayName("Registro Policial")]
        public RegistroPolicial? RegistroPolicial { get; set; }

        [DisplayName("Fornecimento Imagem")]
        public int? FornecimentoImagemId { get; set; }

        [DisplayName("Fornecimento Imagem")]
        public FornecimentoImagem? FornecimentoImagem { get; set; }

        [DisplayName("Fornecimento Evento Alarme")]
        public int? FornecimentoEventoAlarmeId { get; set; }

        [DisplayName("Fornecimento Evento Alarme")]
        public FornecimentoEventoAlarme? FornecimentoEventoAlarme { get; set; }

        [DisplayName("Fornecimento Acesso Físico")]
        public int? FornecimentoAcessoFisicoId { get; set; }

        [DisplayName("Fornecimento Acesso Físico")]
        public FornecimentoAcessoFisico? FornecimentoAcessoFisico { get; set; }

        [DisplayName("Em Seguimento")]
        public int? SeguimentoId { get; set; }

        [DisplayName("Em Seguimento")]
        public Seguimento? Seguimento { get; set; }

        [Column(TypeName = "varchar(20)")]
        [DisplayName("Número Registro")]
        public string? NumeroRegistroPolicial { get; set; }

        //[DisplayName("Data Acionamento Operacional")]
        //[Column(TypeName = "datetime")]
        //public DateTime? DataAcionamentoOperacional { get; set; }

        //Conclusão

        [DisplayName("Data Conclusão")]
        [Column(TypeName = "datetime")]
        public DateTime? DataConclusao { get; set; }

        [DisplayName("Dias Conclusão")]
        public int? DiasConclusaoConclusao { get; set; }

        [DisplayName("Dias Conclusão SIS")]
        public int? DiasConclusaoSis { get; set; }

        [DisplayName("Análise Conclusão")]
        public int? AnaliseConclusaoId { get; set; }

        [DisplayName("Análise Conclusão")]
        public AnaliseConclusao? AnaliseConclusao { get; set; }

        [DisplayName("Providência")]
        [Column(TypeName = "varchar(500)")]
        public string? ProvidenciaConclusao { get; set; }

        [DisplayName("Conclusão")]
        [Column(TypeName = "varchar(500)")]
        public string? Conclusao { get; set; }

        //valores

        [DisplayName("Data Alteração Valor")]
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracaoValor { get; set; }

        public string? ValorAlteradoPorId { get; set; }
        public Usuario? ValorAlteradoPor { get; set; }

        [DisplayName("Valor Total")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorPerdaTotal { get; set; }

        [DisplayName("Conteudo Anterior")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorConteudoAnterior { get; set; }

        [DisplayName("Conteudo Atual")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorConteudoAtual { get; set; }

        [DisplayName("Valor Diferenca")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorDiferenca { get; set; }

        [DisplayName("Diferenca Percentual")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double? ValorDiferencaPercentual { get; set; }

        public ICollection<Observacao>? Observacao { get; set; }
        public ICollection<Dano> Dano { get; set; }
        public ICollection<Anexo> Anexo { get; set; }
        //public ICollection<AlteracaoOcorrencia> AlteracaoOcorrencia { get; set; }
        public ICollection<Recuperacao> Recuperacao { get; set; }
        public ICollection<AuditoriaDano> AuditoriaDano { get; set; }
        public ICollection<AuditoriaInfrator> AuditoriaInfrator { get; set; }
        public ICollection<Perda>? Perda { get; set; }
        public ICollection<Envolvido>? Envolvido { get; set; }
        public ICollection<TipoOcorrenciaTipoSite> TipoOcorrenciaTipoSites { get; set; }
        public ICollection<LogValor>? LogValor { get; set; }

    }

}
