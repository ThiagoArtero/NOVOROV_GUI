using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class Cmc
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string NomeCmc { get; set; }

        [Column(TypeName = "varchar(20)")]
        [DisplayName("Núcleo")]
        public string Nucleo { get; set; }

        public bool Status { get; set; }
        public ICollection<Ocorrencia> Ocorrencia { get; set; }
        public ICollection<Usuario> Usuario { get; set; }

    }
}
