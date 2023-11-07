using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Models
{
    public class Passivo
    {
        public int Id { get; set; }

        [DisplayName("Valor Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorPassivo { get; set; }

        [DisplayName("Valor Recuperado Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ValorRecuperadoPassivo { get; set; }

        [DisplayName("Tipo de Ressarcimento")]
        public int TipoRessarcimentoId { get; set; }
        public TipoRessarcimento TipoRessarcimento { get; set; }

        [DisplayName("Area Interna")]
        public int AreaInternaId { get; set; }
        public AreaInterna AreaInterna { get; set; }

        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [DisplayName("Perda")]
        public int PerdaId { get; set; }
        public Perda Perda { get; set; }
    }
}
