using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class EmpresaChamadoSis
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeEmpresaChamadoSis { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string? RazaoSocial { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string? Email { get; set; }
    }
}
