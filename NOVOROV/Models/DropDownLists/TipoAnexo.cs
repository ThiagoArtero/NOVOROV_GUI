using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoAnexo
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string NomeTipoAnexo { get; set; }
        public ICollection<Anexo> Anexos { get; set; }
    }
}
