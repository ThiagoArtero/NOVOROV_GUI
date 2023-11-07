using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class RegistroPolicial
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeRegistroPolicial { get; set; }
    }
}
