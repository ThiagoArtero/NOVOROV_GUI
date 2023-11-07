using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class GestaoQualidade
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeGestaoQualidade { get; set; }
        public ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}
