using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoEquipamento
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string NomeTipoEquipamento { get; set; }
        public ICollection<EquipamentoPerda> EquipamentoPerda { get; set; }
        public ICollection<AuditoriaDano> AuditoriaDano { get; set; }
        public ICollection<Perda> Perda { get; set; }
    }
}