using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Recuperacao
    {
        public int Id { get; set; }

        public int DanoId { get; set; }
        public Dano Dano { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        [DisplayName("Número Antigo")]
        public int NumeroAntigo { get; set; }

        [DisplayName("Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Passivo { get; set; }

        [DisplayName("Valor Recuperado Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorRecuperadoPassivo { get; set; }

        public int EmpresaPassivoId { get; set; }
        public EmpresaPassivo EmpresaPassivo { get; set; }

        public int QualificacaoId { get; set; }
        public Qualificacao Qualificacao { get; set; }

        [DisplayName("Data Recuperação")]
        public DateTime DataRecuperacao { get; set; }

        [DisplayName("Valor Evitado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorEvitado { get; set; }

        public int TipoRessarcimentoId { get; set; }
        public TipoRessarcimento TipoRessarcimento { get; set; }

        public int AreaInternaPassivoId { get; set; }
        public AreaInternaPassivo AreaInternaPassivo { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        public DateTime DataValorPassivo { get; set; }
        public DateTime DataValorRecuperadoPassivo { get; set; }

        public int UsuarioValorPassivoId {get;set;}
        public Usuario UsuarioValorPassivo {get;set;}

    }
}
