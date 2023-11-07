using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class Motivo
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Motivo")]
        public string NomeMotivo { get; set; }


        [Column(TypeName = "varchar(500)")]
        [DisplayName("Descrição Motivo")]
        public string DescricaoMotivo { get; set; }
    }
}
