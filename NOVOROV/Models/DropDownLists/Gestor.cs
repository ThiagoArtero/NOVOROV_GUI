using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class Gestor
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeGestor { get; set; }
        public ICollection<Usuario>? Usuario { get; set; }
    }
}
