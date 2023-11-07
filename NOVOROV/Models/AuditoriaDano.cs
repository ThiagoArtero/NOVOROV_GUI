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
    public class AuditoriaDano
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        public int TipoEquipamentoId { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }

        public int Quantidade { get; set; }

        [DisplayName("Valor Dano")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorDano { get; set; }

        [DisplayName("Valor Recuperado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorRecuperado { get; set; }

        [DisplayName("Data Auditoria Dano")]
        public DateTime DataAuditoriaDano { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Controle { get; set; }
    
        //Tipo_Audit
        //Cod_Sin
    
    }
}
