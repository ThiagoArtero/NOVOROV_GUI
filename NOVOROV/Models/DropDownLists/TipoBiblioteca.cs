using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoBiblioteca
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeTipoBiblioteca { get; set; }

        public ICollection<Biblioteca> Biblioteca { get; set; }
    }
}
