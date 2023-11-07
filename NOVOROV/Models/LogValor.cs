using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Models
{
    public class LogValor
    {
        public int Id { get; set; }

        public int? OcorrenciaId { get; set; }
        public Ocorrencia? Ocorrencia { get; set; }


        [DisplayName("Data Alteração")]
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracaoValor { get; set; }

        [DisplayName("Alterado Por")]
        public string? ValorAlteradoPorId { get; set; }
        public Usuario? ValorAlteradoPor { get; set; }

        [DisplayName("Valor Total")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorPerdaTotal { get; set; }

        [DisplayName("Conteúdo Anterior")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorConteudoAnterior { get; set; }

        [DisplayName("Conteúdo Atual")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorConteudoAtual { get; set; }

        [DisplayName("Valor Diferença")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorDiferenca { get; set; }

        [DisplayName("Diferença Percentual")]
        //[DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double? ValorDiferencaPercentual { get; set; }

        public int? TipoOcorrenciaId { get; set; }

        [DisplayName("Tipo Ocorrência")]
        public TipoOcorrencia? TipoOcorrencia { get; set; }

        public int? TipoSiteId { get; set; }
        [DisplayName("Tipo Site")]
        public TipoSite? TipoSite { get; set; }
    }
}
