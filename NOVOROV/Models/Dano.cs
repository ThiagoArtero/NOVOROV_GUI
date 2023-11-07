using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Dano
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string NomeDano { get; set; }

        public int NumeroAntigo { get; set; }
        public int QuantidadeEquipamento { get; set; }

        [DisplayName("Valor Dano")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorDano { get; set; }

        [DisplayName("Valor Recuperado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorRecuperado { get; set; }

        [DisplayName("Valor Evitado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorEvitado { get; set; }

        public DateTime DataDano { get; set; }
        public DateTime DataRecuperado { get; set; }
        public DateTime DataEvitado { get; set; }
        public bool Status { get; set; }
        public int TipoEquipamentoId {get;set;}
        public TipoEquipamento TipoEquipamento { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        public ICollection<Recuperacao> Recuperacao { get; set; }
    }
}
