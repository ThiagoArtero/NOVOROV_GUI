using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOVOROV.Models.DropDownLists;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Envolvido
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nome Envolvido")]
        public string? NomeEnvolvido { get; set; }

        [Column(TypeName = "varchar(15)")]
        [DisplayName("CPF")]
        public string? CPF { get; set; }

        [Column(TypeName = "varchar(15)")]
        [DisplayName("RG")]
        public string? RG { get; set; }

        [Column(TypeName = "varchar(10)")]
        [DisplayName("Placa Veículo")]
        public string? PlacaVeiculo { get; set; }

        [DisplayName("Reincidente")]
        public bool? Reincidente { get; set; }

        //Informações do Envolvimento

        [Column(TypeName = "varchar(200)")]
        [DisplayName("Justificativa")]
        public string? Justificativa { get; set; }

        [DisplayName("Tipo Envolvimento")]
        public int? TipoEnvolvimentoId { get; set; }
        public TipoEnvolvimento? TipoEnvolvimento { get; set; }

        [DisplayName("Ação Tomada")]
        public int? AcaoTomadaId { get; set; }
        public AcaoTomada? AcaoTomada { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

    }
}
