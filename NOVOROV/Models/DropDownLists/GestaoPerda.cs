using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class GestaoPerda
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeGestaoPerda{ get; set; }
        public ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}
