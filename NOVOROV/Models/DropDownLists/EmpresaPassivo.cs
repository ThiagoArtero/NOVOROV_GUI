using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class EmpresaPassivo
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Empresa Passivo")]
        public string NomeEmpresaPassivo { get; set; }

        public ICollection<Recuperacao> Recuperacao { get; set; }
    }
}
