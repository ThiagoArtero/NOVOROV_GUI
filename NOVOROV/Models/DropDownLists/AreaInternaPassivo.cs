using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class AreaInternaPassivo
    {
        public int AreaInternaPassivoId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeAreaInternaPassivoo { get; set; }

        public ICollection<Recuperacao> Recuperacao { get; set; }
    }
}
