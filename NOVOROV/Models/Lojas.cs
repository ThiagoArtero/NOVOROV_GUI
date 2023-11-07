using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Lojas
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Estado { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Cidade { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Loja { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Endereço { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Regional { get; set; }
    }
}
