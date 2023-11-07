using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class AuditoriaRecuperacao
    {
        public int Id { get; set; }

        public int DanoId { get; set; }
        public Dano Dano { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        [DisplayName("Valor Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorPassivo { get; set; }

        [DisplayName("Valor Recuperado Passivo")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorRecuperadoPassivo { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Empresa")]
        public string Empresa { get; set; }

        public int QualificacaoId { get; set; }
        public Qualificacao Qualificacao { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }

        public DateTime DataAuditoriaRecuperacao { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int TipoAuditoriaId {get;set;}
        public TipoAuditoria TipoAuditoria { get; set; }

    }
}
