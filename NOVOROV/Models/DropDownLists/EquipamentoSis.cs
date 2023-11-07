using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class EquipamentoSis
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeEquipamentoSis { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string Tipo { get; set; }


        [Column(TypeName = "varchar(5)")]
        public string Motivo { get; set; }
    }
}
