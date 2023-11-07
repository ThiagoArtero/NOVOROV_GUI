using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Area
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SiglaArea { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string DescricaoDenominacao { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SiglaVp { get; set; }

    }
}
