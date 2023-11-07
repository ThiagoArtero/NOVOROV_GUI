using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class Seguimento
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeSeguimento { get; set; }

        public ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}
