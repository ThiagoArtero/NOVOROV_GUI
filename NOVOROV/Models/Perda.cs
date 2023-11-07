using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Models
{
    public class Perda
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [DisplayName("Número B.O Sinistro Rede")]
        public string? NumeroBOSinistroRede { get; set; }

        [DisplayName("Quantidade")]
        public int? QuantidadePerda { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Cód. Sinistro")]
        public string? CodigoSinistro { get; set; }


        [DisplayName("Perda")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorPerda { get; set; }

        //Info da Recuperação

        [DisplayName("Recuperado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorEfetivamenteRecuperado { get; set; }

        [DisplayName("Valor de Perda Evitada")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorPerdaEvitada { get; set; }

        [DisplayName("Total Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalPassivo { get; set; }

        [DisplayName("Total Recuperado Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalRecuperadoPassivo { get; set; }

        [Required]
        [DisplayName("Tipo Equipamento")]
        public int TipoEquipamentoId { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }

        [Required]
        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        public ICollection<Passivo> Passivo { get; set; }
    }
}
