using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class EmpresaProntoAtendimento
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeEmpresaProntoAtendimento { get; set; }
    }
}
