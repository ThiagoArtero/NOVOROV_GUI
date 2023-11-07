using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class Status
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeStatus { get; set; }

        public ICollection<Ocorrencia> Ocorrencia { get; set; }
        public ICollection<Site> Site { get; set; }
    }
}
