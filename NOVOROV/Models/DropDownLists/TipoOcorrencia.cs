using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoOcorrencia
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeTipoOcorrencia { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DescricaoTipoOcorrencia { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

    }
}
