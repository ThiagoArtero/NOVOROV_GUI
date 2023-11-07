using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models.DropDownLists
{
    public class AcaoTomada
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("NomeAcaoTomada")]
        public string? NomeAcaoTomada { get; set; }

        public ICollection<Envolvido> Envolvido { get; set; }
    }
}
