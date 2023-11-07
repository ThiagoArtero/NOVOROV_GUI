using NOVOROV.Models.DropDownLists;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class ModeloRelatorio
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeModelo { get; set; }

        public int? TipoRelatorioId { get; set; }
        public TipoRelatorio? TipoRelatorio { get; set; }

        public bool? NumeroRov { get; set; }
        public bool? AcionadoProntoAtendimento { get; set; }
        public bool? AlarmeRealAcidental { get; set; }
        public bool? Ambiente { get; set; }
        public bool? AnaliseConclusao { get; set; }
        public bool? AreaInterna { get; set; }
        public bool? AreaSaude { get; set; }
        public bool? AreaTratamento { get; set; }
        public bool? AtendeuSla { get; set; }
        public bool? BombeiroCivil { get; set; }
        public bool? CargoFuncao { get; set; }
        public bool? CEP { get; set; }
        public bool? Cmc { get; set; }
        public bool? CodigoSinistro { get; set; }
        public bool? Conclusao { get; set; }
        public bool? Condutor { get; set; }
        public bool? DataConclusao { get; set; }
        public bool? DataConclusaoChamado { get; set; }
        public bool? DataOcorrencia { get; set; }
        public bool? DataConclusaoSis { get; set; }
        public bool? DataReagendamentoSis { get; set; }
        public bool? DataRegistro { get; set; }
        public bool? Detentora { get; set; }
        public bool? DiasConclusao { get; set; }
        public bool? EmSeguimento { get; set; }
        public bool? Empresa { get; set; }
        public bool? Endereco { get; set; }
        public bool? EventoErb { get; set; }
        public bool? Historico { get; set; }
        public bool? Inbox { get; set; }
        public bool? InformacaoComplementar { get; set; }
        public bool? Local { get; set; }
        public bool? Manutencao { get; set; }
        public bool? Municipio { get; set; }
        public bool? NomeSite { get; set; }
        public bool? Placa { get; set; }
        public bool? Qualificacao { get; set; }
        public bool? ResponsavelOperacional { get; set; }
        public bool? Seguimento { get; set; }
        public bool? SistemaFechaduraBluetooth { get; set; }
        public bool? SistemaRastreamento { get; set; }
        public bool? Status { get; set; }
        public bool? TipoAlarme { get; set; }
        public bool? TipoSite { get; set; }
        public bool? TipoOcorrencia { get; set; }
        public bool? Transportadora { get; set; }
        public bool? Observacao { get; set; }
        public bool? UF { get; set; }
        public bool? UsuarioAlteracaoOcorrencia { get; set; }

    }
}
