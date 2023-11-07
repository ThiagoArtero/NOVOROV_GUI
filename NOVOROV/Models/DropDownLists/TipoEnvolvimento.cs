using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoEnvolvimento
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Tipo Envolvimento")]
        public string? NomeTipoEnvolvimento { get; set; }

        public ICollection<Envolvido> Envolvido { get; set; }
    }
}
