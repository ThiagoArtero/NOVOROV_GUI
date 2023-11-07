using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoSite
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeTipoSite { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }

        public ICollection<Ocorrencia> Ocorrencia { get; set; }
        public ICollection<Site> Site { get; set; }

        public ICollection<TipoOcorrenciaTipoSite> TipoOcorrenciaTipoSites { get; set; }
    }
}
